using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using FluentValidation.Results;
using Xamarin.Forms;

namespace Xamarin.Presentation.Validations {
    using System.ComponentModel;
    using FluentValidation;
    using Xamarin.Presentation.Framework;

    /// <summary>
    /// Object validation state.
    /// provide methods to check property of dependent object
    /// </summary>
    public interface IValidationState {
        string GetError(string propertyName);
        bool IsValid(string propertyName);
    }
    public interface IViewStateValidator {
        IValidationState State { get; }
        bool HasFailures { get; }
        void PushChanges();
    }
    /// <summary>
    /// Abstraction over fluent valistion libs
    /// combine validation of whole ViewState proprties and collect all validation error inside
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <remarks>
    /// profits:
    /// - able to describe validating rules for whole object
    /// - able to check validity of property through common State
    /// - abel to create one ICommand to verify whole object
    /// </remarks>
    public class ViewStateValidator<T> : AbstractValidator<T>, IViewStateValidator, INotifyPropertyChanged {
        class ValidationState : IValidationState {
            readonly Dictionary<string, ValidationFailure> failures;
            public ValidationState(Dictionary<string, ValidationFailure> failures) {
                this.failures = failures;
            }
            public string GetError(string propertyName) {
                if (failures.TryGetValue(propertyName, out var failure)) {
                    return failure.ErrorMessage;
                }
                return null;
            }
            public bool IsValid(string propertyName) {
                return failures.ContainsKey(propertyName);
            }
        }

        readonly Dictionary<string, ValidationFailure> failures;

        public event PropertyChangedEventHandler PropertyChanged;

        public bool HasFailures => failures.Count > 0;
        public IValidationState State { get; }

        public ViewStateValidator() {
            failures = new Dictionary<string, ValidationFailure>();
            State = new ValidationState(failures);
        }

        public new bool Validate(T value) {
            failures.Clear();
            var valres = base.Validate(value);

            foreach (var er in valres.Errors.GroupBy(x => x.PropertyName)) {
                failures[er.Key] = er.First();
            }

            return valres.IsValid;
        }

        public void PushChanges() {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(HasFailures)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(State)));

        }

        //public void Example() {
        //    RuleFor(x => x.UserName).NotNull().Length(10, 20);
        //    RuleFor(x => x.Password).NotNull();
        //    RuleFor(x => x.ConfirmPassword).NotNull().Equal(x => x.Password);
        //    RuleFor(x => x.Email).NotNull().EmailAddress();
        //}
    }

    public interface IValidationRule<T> {
        IEnumerable<string> ErrorMessages { get; }

        bool Validate(T value);
        IRuleBuilderInitial<T, TProperty> RuleFor<TProperty>(Expression<Func<T, TProperty>> expression);
    }
    //public interface IValidatableObject {
    //    bool IsValid { get; set; }
    //    string GetValidationMessage(string property);

    //}

   

    public abstract class ExtendedBindableObject : BindableObject {
        public void RaisePropertyChanged<T>(Expression<Func<T>> property) {
            var name = GetMemberInfo(property).Name;
            OnPropertyChanged(name);
        }

        private MemberInfo GetMemberInfo(Expression expression) {
            MemberExpression operand;
            LambdaExpression lambdaExpression = (LambdaExpression)expression;
            if (lambdaExpression.Body as UnaryExpression != null) {
                UnaryExpression body = (UnaryExpression)lambdaExpression.Body;
                operand = (MemberExpression)body.Operand;
            } else {
                operand = (MemberExpression)lambdaExpression.Body;
            }
            return operand.Member;
        }
    }

    public class ValidatableObject<T> : BaseNotify {
         readonly IValidationRule<ValidatableObject<T>> validation;
         List<string> _errors;
         T _value;
         bool _isValid;


        public List<string> Errors {
            get {
                return _errors;
            }
            set {
                _errors = value;
                SetPropertyChanged();
            }
        }

        public T Value {
            get {
                return _value;
            }
            set {
                _value = value;
                SetPropertyChanged();
            }
        }

        public bool IsValid {
            get {
                return _isValid;
            }
            set {
                _isValid = value;
                SetPropertyChanged();
            }
        }

        public ValidatableObject() {
            _isValid = true;
            _errors = new List<string>();
           // validation = new ValidationRule<ValidatableObject<T>>();
        }

        public IRuleBuilderInitial<ValidatableObject<T>, T> BuildRule() {
            return validation.RuleFor(x=>x.Value);
        }


        public bool Validate() {
            Errors.Clear();

            IsValid = validation.Validate(this);
           // Errors = validation.ErrorMessages.ToList();

            return this.IsValid;
        }
    }
}
