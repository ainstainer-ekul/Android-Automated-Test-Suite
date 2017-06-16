Feature: Login

###   Scenario 1 - Done
	Scenario: User can log in
		When tap 'Sign In' button on [Home] tab
		And fill in a email field with 'pre-setup evgeniy.kulikov@ainstainer.de' on [Login] tab
		And fill in a password field with 'Testing123' on [Login] tab
		And tap 'Done' button on [Login] tab
		And tap 'Ok' button on [SoundCloud won't run without Google Play services] popup
		Then should see 'Search SoundCloud' placeholder text 'Search' field on [Search] tab


###   Scenario 2 - Done
	Scenario: Error popup is displayed after an attempt to log in with wrong credentials
		When tap 'Sign In' button on [Home] tab
		And fill in a email field with 'pre-setup evgeniy.kulikov@ainstainer.de' on [Login] tab
		And fill in a password field with 'wrongPass' on [Login] tab
		And tap 'Done' button on [Login] tab
		Then should see an error popup with a following text:
		"""
		We couldn’t sign you in. Sure you have the right email and password?
		"""


###   Scenario 3 - in progress
	@featureInProgress
	Scenario: User can log in using facebook
		When tap 'Sign In' button on [Home] tab
		And tap 'Sign in with Facebook' button on [Login] tab
		And tap 'Continue' button on [One more step] tab
		And fill in a email field with 'pre-setup evgeniy.kulikov@ainstainer.de' on [Facebook] tab
		And fill in a password field with 'Testing159' on [Facebook] tab
		And tap 'Log In' button on [One more step] tab








		
