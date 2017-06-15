
Feature: UserProfile

	Scenario: User can not to see his avatar in the full screen mode
		When tap 'Sign In' button on [Home] tab
		And fill in a email field with 'pre-setup evgeniy.kulikov@ainstainer.de' on [Login] tab
		And fill in a password field with 'Testing123' on [Login] tab
		And tap 'Done' button on [Login] tab
		And tap 'More' button on navigation bar
		And tap 'Avatar' image on [More] tab
		And tap 'Avatar' image on [You] tab
		Then should see 'There was a problem loading the image' toast