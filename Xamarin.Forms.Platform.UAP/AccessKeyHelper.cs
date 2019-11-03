using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Xamarin.Forms.PlatformConfiguration.WindowsSpecific;
using VisualElementSpecifics = Xamarin.Forms.PlatformConfiguration.WindowsSpecific.VisualElement;

namespace Xamarin.Forms.Platform.UWP
{
	static class AccessKeyHelper
	{
		static readonly bool KeyTipPlacementModeApiPresent = Windows.Foundation.Metadata.ApiInformation.IsPropertyPresent(typeof(UIElement).FullName, nameof(UIElement.KeyTipPlacementMode));
		static readonly bool KeyTipHorizontalOffsetApiPresent = Windows.Foundation.Metadata.ApiInformation.IsPropertyPresent(typeof(UIElement).FullName, nameof(UIElement.KeyTipHorizontalOffset));
		static readonly bool KeyTipVerticalOffsetApiPresent = Windows.Foundation.Metadata.ApiInformation.IsPropertyPresent(typeof(UIElement).FullName, nameof(UIElement.KeyTipVerticalOffset));

		public static void UpdateAccessKey(FrameworkElement control, VisualElement element) {

			if (control != null && element is IElementConfiguration<VisualElement> elementConfig)
			{
				var windowsElement = elementConfig.On<PlatformConfiguration.Windows>();
				if (element.IsSet(VisualElementSpecifics.AccessKeyProperty))
					control.AccessKey = windowsElement.GetAccessKey();

				if (KeyTipPlacementModeApiPresent)
				if (element.IsSet(VisualElementSpecifics.AccessKeyPlacementProperty))
				{
					switch (windowsElement.GetAccessKeyPlacement())
					{
						case AccessKeyPlacement.Auto:
							control.KeyTipPlacementMode = KeyTipPlacementMode.Auto;
							break;
						case AccessKeyPlacement.Bottom:
							control.KeyTipPlacementMode = KeyTipPlacementMode.Bottom;
							break;
						case AccessKeyPlacement.Center:
							control.KeyTipPlacementMode = KeyTipPlacementMode.Center;
							break;
						case AccessKeyPlacement.Left:
							control.KeyTipPlacementMode = KeyTipPlacementMode.Left;
							break;
						case AccessKeyPlacement.Right:
							control.KeyTipPlacementMode = KeyTipPlacementMode.Right;
							break;
						case AccessKeyPlacement.Top:
							control.KeyTipPlacementMode = KeyTipPlacementMode.Top;
							break;
					}
				}

				if (KeyTipHorizontalOffsetApiPresent)
					if (element.IsSet(VisualElementSpecifics.AccessKeyHorizontalOffsetProperty))
						control.KeyTipHorizontalOffset = windowsElement.GetAccessKeyHorizontalOffset();

				if (KeyTipVerticalOffsetApiPresent)
					if (element.IsSet(VisualElementSpecifics.AccessKeyVerticalOffsetProperty))
						control.KeyTipVerticalOffset = windowsElement.GetAccessKeyVerticalOffset();
			}
		}
	}
}
