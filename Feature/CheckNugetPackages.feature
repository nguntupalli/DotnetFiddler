Feature: CheckNugetPackages
	In order to check the functionality of the .Net Fiddle page

@test
Scenario: Check Nuget packages
	Given the first Name starts with <Letters> in <Name>
	When the <Action> is performed
	Then the <Outcome> is expected

	Examples: 
	| letters     | Name          | Action                                     | Outcome                                          |
	| A-B-C-D-E   | Donald Trump  | NuGet Packages: nUnit (3.12.0) is selected | nUnit package is added                           |
	| A-B-C-D-E   | Boris Johnson | NuGet Packages: nUnit (3.12.0) is selected | nUnit package is added                           |
	| F-G-H-I-J-K | Freida Kahlo  | “Share” button is clicked                  | the link starts with `https://dotnetfiddle.net/` |
	| L-M-N-O-P   | Owen Pascal   | Options panel hide button is clicked       | “Options” panel is hidden                        |
	| Q-R-S-T-U   | Tony Swan     | Save button is clicked                     | Login window is displayed                        |
	| V-W-X-Y-Z   | Yen Pal       | Getting started button is clicked          | Back to Editor button appears                    |
	| V-W-X-Y-Z   | young Pal     | Getting started button is clicked          | Back to Editor button appears                    |
