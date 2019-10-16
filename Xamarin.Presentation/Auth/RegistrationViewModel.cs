using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using FluentValidation;
using Xamarin.Forms;
using Xamarin.Presentation.Framework.VSVVM;
using Xamarin.Presentation.Pages.States;
using Xamarin.Presentation.Validations;

namespace Xamarin.Presentation.Auth {
    public class RegistrationViewState : BaseViewState {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }

        public string Pass { get; set; }
        public string RepeatPass { get; set; }

        public DateTime Birthday { get; set; }

        public RegistrationViewState() {
            Birthday = DateTime.Now;
        }
    }

    public abstract class RegistrationViewModel<TViewState> : IPageStates where TViewState : RegistrationViewState {
        public PageStates State { get; protected set; }
        public TViewState ViewState { get; protected set; }
        public ViewStateValidator<RegistrationViewState> Validator { get; }

        public ICommand Register { get; }
        public ICommand Validate { get; }

      


        bool showAllValidationErrors;

        public RegistrationViewModel() {
            showAllValidationErrors = true;
            Register = new Command(OnRegister);
            Validate = new Command(OnValidate);

            Validator = new ViewStateValidator<RegistrationViewState>();
            Validator.RuleFor(x => x.Email).NotEmpty().EmailAddress();
            Validator.RuleFor(x => x.LastName).NotEmpty().MinimumLength(3);
            Validator.RuleFor(x => x.Pass).NotEmpty().MinimumLength(5);
            Validator.RuleFor(x => x.RepeatPass).NotEmpty().Equal(x => x.Pass).WithMessage("Passwords do not match.");
        }

        protected void Init() {
#if DEBUG
            var ticks = DateTime.Now.Ticks;
            ViewState.Birthday = DateTime.Now;
            ViewState.Email = $"email{ticks}@email.test";
            ViewState.FirstName = $"FirstName{ticks}";
            ViewState.Gender = "Female";
            ViewState.LastName = $"LastName{ticks}";
            //vs.Locale = ;
            //vs.Login = ;
            //vs.MiddleName = ,
            ViewState.Pass = $"Pass{ticks}";
            //vs.SocialConfirmRecordId = , 
#endif
        }

        internal void OnValidate(object obj) {
            if (showAllValidationErrors) {
                Validator.Validate(ViewState);
                Validator.PushChanges();
            }
        }

        internal void OnRegister(object obj) {
            var state = ViewState;
            if (Validator.Validate(state)) {
                OnRegister(state);
            } else {
                showAllValidationErrors = true;
                Validator.PushChanges();
            }
        }

        protected abstract void OnRegister(TViewState state);

        


        #region 

        //class EmailValidator : ValidationRule<string> {
        //    public EmailValidator() {
        //        RuleFor(x=>x).NotNull().EmailAddress();
        //    }
        //}


        #endregion
    }
}
