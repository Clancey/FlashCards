// 
//  Copyright 2012  James Clancey, Xamarin Inc  (http://www.xamarin.com)
// 
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
// 
//        http://www.apache.org/licenses/LICENSE-2.0
// 
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
using System;
using System.Collections.Generic;
using System.Linq;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace FlashCards
{
	// The UIApplicationDelegate for the application. This class is responsible for launching the 
	// User Interface of the application, as well as listening (and optionally responding) to 
	// application events from iOS.
	[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		// class-level declarations
		UIWindow window;

		//
		// This method is invoked when the application has loaded and is ready to run. In this 
		// method you should instantiate the window, load the UI into it and then make the window
		// visible.
		//
		// You have 17 seconds to return from this method, or iOS will terminate your application.
		//
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			// create a new window instance based on the screen size
			window = new UIWindow (UIScreen.MainScreen.Bounds);
			
			
			window.RootViewController = new FlashCardViewController(GetCards());
			
			// make the window visible
			window.MakeKeyAndVisible ();
			
			return true;
		}
		
		private List<FlashCard> GetCards()
		{
			return new List<FlashCard>()
			{
				new FlashCard(){Word = "cat",Image="Images/cat.jpg"},
				new FlashCard(){Word = "wave",Image="Images/boyWave.jpg"},
				new FlashCard(){Word = "clap",Image="Images/clap.JPG"},
				new FlashCard(){Word = "dog",Image="Images/dog.jpg"},
				new FlashCard(){Word = "eyes",Image="Images/eyes.jpg"},
				new FlashCard(){Word = "arms up",Image="Images/girlArmsUp.jpg"},
				new FlashCard(){Word = "nose",Image="Images/nose.JPG"},
				new FlashCard(){Word = "toes",Image="Images/Toes.jpg"},
				
			};
		}
	}
}

