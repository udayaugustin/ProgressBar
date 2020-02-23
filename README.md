This packages adds multi color segment bar in Xamarin forms. This is purely written using xamarin forms control.

To Consume:
* Add the nugget package "MultiColor.ProgressBar" to Xamarin Forms Project. No need to add in the platform specific project.
* Declare the name space in the xaml. xmlns:progressBar="car-namespace:ProgressBar;assembly=ProgressBar"
* Use the below xaml to add the progress bar control to your view.

```xml
<progressBar:ProgressBar ProgressBarHeight="10" ProgressBarWidth="250" CornerRadius="5" VerticalOptions="CenterAndExpand" HorizontalOptions="Center">
<progressBar:ProgressBar.BarList>
<progressBar:BarSegment BarWidth="10*" BarColor="Green"/>
<progressBar:BarSegment BarWidth="20*" BarColor="Yellow"/>
<progressBar:BarSegment BarWidth="30*" BarColor="Blue"/>
<progressBar:BarSegment BarWidth="30*" BarColor="Gold"/>
<progressBar:BarSegment BarWidth="10*" BarColor="Red"/>
</progressBar:ProgressBar.BarList>
</progressBar:ProgressBar>
```
