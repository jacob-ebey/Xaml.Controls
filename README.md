## Xaml.Controls [![Build status](https://ci.appveyor.com/api/projects/status/cddcp26rgko0o55x/branch/master?svg=true)](https://ci.appveyor.com/project/jacob-ebey/xaml-controls/branch/master)

Xaml.Controls was created to contain controls to help ease in developing dynamic cross platform mobile applications.


### Installing

Xaml.Controls is available through nugget [HERE](https://www.nuget.org/packages/Jacob.Ebey.Xaml.Controls/).


### Controls

* [ContentSelectorView](https://github.com/jacob-ebey/Xaml.Controls/blob/master/Xaml.Controls/Controls/ContentSelectorView.cs) - Used to select a view dynamically based on the binding context. See an example [HERE](https://github.com/jacob-ebey/Xaml.Controls/blob/master/Demo.Xaml.Controls/Views/ContentSelectorViewDemo.xaml) with the ViewCreatorProvider used [HERE](https://github.com/jacob-ebey/Xaml.Controls/blob/master/Demo.Xaml.Controls/ViewCreators/ContentSelectorViewCreator.cs).

* [ViewSelectorListView](https://github.com/jacob-ebey/Xaml.Controls/blob/master/Xaml.Controls/Controls/ViewSelectorListView.cs) - Used to select a view for a list based on the item that needs to be displayed. See an example [HERE](https://github.com/jacob-ebey/Xaml.Controls/blob/master/Demo.Xaml.Controls/Views/ViewSelectorListViewDemo.xaml) with the ViewCreatorProvider used [HERE](https://github.com/jacob-ebey/Xaml.Controls/blob/master/Demo.Xaml.Controls/ViewCreators/ViewSelectorViewCreator.cs)


### Using the controls

Reference the assembly namespace and view the examples above. More documentation to come.
```xml
xmlns:controls="clr-namespace:Xaml.Controls;assembly=Xaml.Controls"
```
