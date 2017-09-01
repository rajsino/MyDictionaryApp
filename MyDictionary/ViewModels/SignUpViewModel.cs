#region FileHeader
// ***********************************************************************
// Assembly         : MyDictionary
// Author           : Sino Raj
// Created          : 27-08-2017
//
// ***********************************************************************
// <copyright file="SignUpViewModel.cs" company="Dreamz">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
#endregion
using System.Windows.Input;
using System.Linq;
using MyDictionary.BaseValidation;
using MyDictionary.Components.Validations;
using Xamarin.Forms;
using System;
using MyDictionary.Components.Interfaces;
using MyDictionary.Components.Models.Users;
using MyDictionary.Components.Utils;
using System.Diagnostics;

namespace MyDictionary.ViewModels
{
	public class SignUpViewModel : ViewModelBase
	{
		private ValidatableObject<string> _email;
		private ValidatableObject<string> _password;
		private ValidatableObject<string> _repeatPassword;
		private ValidatableObject<string> _firstName;
		private ValidatableObject<string> _lastName;
		private DateTime _birthDate;
		private bool _isValid;

		private IProfileService _profileService = null;
		private IAuthenticationService _authenticationService = null;

		public SignUpViewModel(IProfileService profileService, IAuthenticationService authenticationService)
		{
			_email = new ValidatableObject<string>();
			_password = new ValidatableObject<string>();
			_repeatPassword = new ValidatableObject<string>();
			_firstName = new ValidatableObject<string>();
            _lastName = new ValidatableObject<string>();
			_profileService = profileService;
			_authenticationService = authenticationService;

            BirthDate = DateTime.Today;

			AddValidations();
		}

		public ValidatableObject<string> Email
		{
			get
			{
				return _email;
			}
			set
			{
				_email = value;
				RaisePropertyChanged(() => Email);
			}
		}

		public ValidatableObject<string> Password
		{
			get
			{
				return _password;
			}

			set
			{
				_password = value;
				RaisePropertyChanged(() => Password);
			}
		}

		public ValidatableObject<string> RepeatPassword
		{
			get
			{
				return _repeatPassword;
			}

			set
			{
				_repeatPassword = value;
				RaisePropertyChanged(() => RepeatPassword);
			}
		}

		public ValidatableObject<string> FirstName
		{
			get
			{
				return _firstName;
			}
			set
			{
				_firstName = value;
				RaisePropertyChanged(() => FirstName);
			}
		}

		public ValidatableObject<string> LastName
		{
			get
			{
				return _lastName;
			}

			set
			{
				_lastName = value;
				RaisePropertyChanged(() => LastName);
			}
		}

		public DateTime BirthDate
		{
			get
			{
				return _birthDate;
			}

			set
			{
				_birthDate = value;
				RaisePropertyChanged(() => BirthDate);
			}
		}

		public bool IsValid
		{
			get
			{
				return _isValid;
			}

			set
			{
				_isValid = value;
				RaisePropertyChanged(() => IsValid);
			}
		}

		public ICommand NextCommand
		{
			get { return new Command<object>((n) => Next(n)); }
		}

		public ICommand ValidateCommand
		{
			get { return new Command(() => Validate()); }
		}

		public bool Validate()
		{
			bool isValidEmail = _email.Validate();

			bool isValidPassword = _password.Validate();
			bool isValidRepeatedPassword = _repeatPassword.Validate();

			bool isValidFirstName = _firstName.Validate();
			bool isValidLastName = _lastName.Validate();

			return isValidEmail && isValidPassword && isValidRepeatedPassword && isValidFirstName && isValidLastName;
		}

		private void AddValidations()
		{
			_email.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Email should not be empty" });
			_email.Validations.Add(new EmailRule<string> { ValidationMessage = "Invalid Email" });
			_password.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Password should not be empty" });
			_repeatPassword.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Repeat password should not be empty" });
			_firstName.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "First Name should not be empty" });
            _lastName.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Last Name should not be empty" });
		}

		private async void Next(object navigate)
		{
			IsBusy = true;
			IsValid = true;
			bool isValid = Validate();

			if (isValid)
			{
                try
                {                   
                    string gender = "Male";

                    var userAndProfile = new UserAndProfileModel
					{
						UserName = Email.Value,
						Password = Password.Value,
						Gender = gender,
						BirthDate = BirthDate,
						FirstName = FirstName.Value,
						LastName = LastName.Value,
						Email = Email.Value,
						TenantId = GlobalSettings.TenantId
					};

                    UserAndProfileModel result = await _profileService.SignUp(userAndProfile);

                    if (result != null)
                    {
                        bool isAuthenticated =
							await _authenticationService.LoginAsync(userAndProfile.UserName, userAndProfile.Password);

                        if (isAuthenticated)
                        {
                            await NavigationService.NavigateToAsync<BaseViewModel>();
                        }
                        else
                        {
                            await DialogService.ShowAlertAsync("Invalid credentials", "Login failure", "Try again");
                        }
                    }
                    else
                    {
                        await DialogService.ShowAlertAsync("Invalid data", "Sign Up failure", "Try again");
                    }
                }
                catch(Exception ex)
                {
                    Debug.WriteLine($"Exception in sign up {ex}");
					if(ex == null)
                    	await DialogService.ShowAlertAsync("Invalid data", "Sign Up failure", "Try again");
					else
						await DialogService.ShowAlertAsync("Invalid data\n", "Sign Up failure", "Try again");
                }
			}
			else
			{
				await DialogService.ShowAlertAsync("Invalid data", "Please enter correct data and continue", "Try again");
				IsValid = false;
			}

			IsBusy = false;
		}

		private void AddDynamicValidations()
		{
			if (_repeatPassword.Validations
				.Any(v => v.GetType().Equals(typeof(RepeatPasswordRule<string>))))
			{
				var validation = _repeatPassword.Validations.First(v => v.GetType().Equals(typeof(RepeatPasswordRule<string>)));
				_repeatPassword.Validations.Remove(validation);
			}

			_repeatPassword.Validations.Add(new RepeatPasswordRule<string> { ValidationMessage = "The passwords do not match", Password = Password.Value });

		}
	}
}