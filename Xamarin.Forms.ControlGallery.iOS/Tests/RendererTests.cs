using System.Threading.Tasks;
using NUnit.Framework;

namespace Xamarin.Forms.ControlGallery.iOS.Tests
{
	[TestFixture]
	[Internals.Preserve(AllMembers = true)]
	public class RendererTests : PlatformTestFixture
	{
		[Test(Description = "Basic sanity check that Label text matches renderer text")]
		public async Task LabelTextMatchesRendererText()
		{
			await Device.InvokeOnMainThreadAsync(() =>
			{
				var label = new Label { Text = "foo" };
				using (var uiLabel = GetNativeControl(label))
				{
					Assert.That(label.Text == uiLabel.Text);
				}
			});

			Assert.Pass();
		}
	}
}