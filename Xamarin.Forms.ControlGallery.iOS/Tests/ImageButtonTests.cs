using System;
using System.Collections;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using UIKit;

namespace Xamarin.Forms.ControlGallery.iOS.Tests
{
	public class ImageButtonTests : PlatformTestFixture
	{

		[Test(), Category("ImageButton")]
		[Description("ImageButton Aspects")]
		public void ImageButtonAspect()
		{
			StackLayout stackLayout = new StackLayout();
			string imageSource = "coffee.png";

			ImageButton imageButtonFill = new ImageButton()
			{
				Source = imageSource,
				Aspect = Aspect.Fill,
				AutomationId = "TestImage"
			};


			ImageButton imageButtonurl = new ImageButton()
			{
				Source = "https://raw.githubusercontent.com/xamarin/Xamarin.Forms/master/Xamarin.Forms.ControlGallery.iOS/Resources/xamarin_logo%403x.png"
			};

			stackLayout.Children.Add(imageButtonFill);
			stackLayout.Children.Add(imageButtonurl);

			ContentPage contentPage = new ContentPage()
			{
				Content = stackLayout
			};

			using(var pageRenderer = GetRenderer(contentPage))
			{
				contentPage.Layout(new Rectangle(0, 0, 1200, 1200));

				// if I use a local image the image actually does load but I fear that this
				// is just luck and at some point it might randomly break
				var image = GetNativeControl(imageButtonFill).ImageView.Image;

				// to illustrate async loading I added this image which uses a url
				// which will be delayed with loading. Here you'll notice this is null
				var imageUrl = GetNativeControl(imageButtonurl).ImageView.Image;
			}
		}
	}
}