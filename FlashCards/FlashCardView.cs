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

namespace FlashCards
{
	public class FlashCardView : UIView
	{
		UILabel Word;
		UIImageView Image;
		UIView backgroundView;
		public FlashCard Flashcard;

		public FlashCardView (FlashCard flashcard)
		{
			backgroundView = new UIView(){BackgroundColor = UIColor.Black};
			this.BackgroundColor = UIColor.Black;
			Flashcard = flashcard;
			Word = new UILabel (){Text = Flashcard.Word,AdjustsFontSizeToFitWidth = true,BackgroundColor = UIColor.White,Font = UIFont.BoldSystemFontOfSize(200),TextAlignment = UITextAlignment.Center};
			Image = new UIImageView (new UIImage (Flashcard.Image));
			this.AddSubview(backgroundView);
			backgroundView.AddSubview (Word);			
			this.AddGestureRecognizer(new UITapGestureRecognizer(Tapped));
		}
		private void Tapped(UITapGestureRecognizer recognizer)
		{
			SwitchViews(true);
		}
		public override void LayoutSubviews ()
		{
			base.LayoutSubviews ();
			this.backgroundView.Frame = this.Bounds;
			Word.Frame = this.Bounds;
			Image.Frame = this.Bounds;
		}

		public void SwitchViews (bool animated)
		{
			UIView.BeginAnimations ("Flipper");
			UIView.SetAnimationDuration (1.25);
			UIView.SetAnimationCurve (UIViewAnimationCurve.EaseInOut);
			
			if (Word.Superview == null) {
				UIView.SetAnimationTransition (UIViewAnimationTransition.FlipFromRight, backgroundView, true);
			
				Image.RemoveFromSuperview ();
				backgroundView.AddSubview (Word);
			
			} else {
				UIView.SetAnimationTransition (UIViewAnimationTransition.FlipFromLeft, backgroundView, true);
				Word.RemoveFromSuperview ();
				backgroundView.AddSubview (Image);
			}
			UIView.CommitAnimations ();
		}
		public override void WillMoveToSuperview (UIView newsuper)
		{
			base.WillMoveToSuperview (newsuper);
			if(newsuper == null)
				return;
			this.Frame = newsuper.Bounds;
		}
	}
}

