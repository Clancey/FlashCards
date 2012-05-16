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
using MonoTouch.UIKit;
using System.Collections.Generic;

namespace FlashCards
{
	public class FlashCardViewController : UIViewController
	{
		List<FlashCard> FlashCards;
		int currentFlashCard = 0;
		FlashCardView FlashCardView;
		public FlashCardViewController (List<FlashCard> flashCards)
		{
			FlashCards = flashCards;
			
			this.View.AddGestureRecognizer(new UISwipeGestureRecognizer(Swiped){Direction = UISwipeGestureRecognizerDirection.Left});
			this.View.AddGestureRecognizer(new UISwipeGestureRecognizer(Swiped){Direction = UISwipeGestureRecognizerDirection.Right});
		}
		private void Swiped(UISwipeGestureRecognizer recognizer)
		{
			var direction = recognizer.Direction;
			if(direction == UISwipeGestureRecognizerDirection.Right)
				{
					currentFlashCard --;
					SetFlashCard(UIViewAnimationTransition.CurlDown);
				}
				else if(direction == UISwipeGestureRecognizerDirection.Left)
				{
					currentFlashCard ++;
					SetFlashCard(UIViewAnimationTransition.CurlUp);
				}
		}
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			FlashCardView = new FlashCardView(FlashCards[currentFlashCard]);
			FlashCardView.Frame = this.View.Bounds;
			this.View.AddSubview(FlashCardView);
			
		}
		
		public void SetFlashCard(UIViewAnimationTransition transition)
		{
			if(currentFlashCard <0)
				currentFlashCard = FlashCards.Count - 1;
			else if(currentFlashCard >= FlashCards.Count)
				currentFlashCard = 0;
			FlashCard newFlashCard = FlashCards[currentFlashCard];
			if(FlashCardView != null && newFlashCard == FlashCardView.Flashcard)
				return;
			
			
			UIView.BeginAnimations ("swipe");
			UIView.SetAnimationDuration (1.25);
			UIView.SetAnimationCurve (UIViewAnimationCurve.EaseInOut);
			
			
			UIView.SetAnimationTransition (transition, this.View, false);
			
			FlashCardView.RemoveFromSuperview ();
			FlashCardView = new FlashCardView(newFlashCard);
			this.View.AddSubview (FlashCardView);
			
			
			UIView.CommitAnimations ();
			
		}
		public override bool ShouldAutorotateToInterfaceOrientation (UIInterfaceOrientation toInterfaceOrientation)
		{
			return true;
		}
		public override void ViewWillLayoutSubviews ()
		{
			base.ViewWillLayoutSubviews ();
			FlashCardView.Frame = this.View.Bounds;
		}
		public override void DidRotate (UIInterfaceOrientation fromInterfaceOrientation)
		{
			base.DidRotate (fromInterfaceOrientation);
			FlashCardView.Frame = this.View.Bounds;
			
		}
		
	}
}

