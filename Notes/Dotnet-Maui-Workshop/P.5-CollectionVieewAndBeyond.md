# Collection View

## Refresh Lists and Collections
`ListViews` have builtin support for pull-to-refresh, however the `RefreshView` component enables `ScrollView` and `CollectionView` to implement the pull-to-refresh behavior

### Adding a Pull to refresh
- `Views/MainPage.xaml`
``` xaml
 <RefreshView
      Grid.ColumnSpan="2"
    Command="{Binding GetMonkeysCommand}"
    IsRefreshing="{Binding IsRefreshing}">>
     <ContentView>
         <CollectionView  
             ItemsSource="{Binding Monkeys}"
             SelectionMode="None">
                // ...
         </CollectionView>

     </ContentView>
 </RefreshView>
```

- `ViewModel/MainViewModel.cs`
```cs
bool isRefreshing;
public bool IsRefreshing
{
    get => isRefreshing;
    set
    {
        isRefreshing = value;
        OnPropertyChanged();
    }

}

// ...

async Task GetMonkeysAsync()
{
// ...
    finally
    {
        IsBusy = false;
        IsRefreshing = false; 
    } 
}
```
## Layouts
`CollectionView` will automatically layout items in a vertical stack. But there are sseveral built in `ItemLayout` to choose from

### LinearItemsLayout

Default Layout that can display itens vertically or horizontally.
```xaml
<CollectionView
    ItemsSource="{Binding Monkeys}"
    SelectionMode="None">
    <!-- Add ItemsLayout -->
    <CollectionView.ItemsLayout>
        <LinearItemsLayout Orientation="Vertical" />
    </CollectionView.ItemsLayout>
    <!-- ItemTemplate -->
</CollectionView>
```

### GridItemsLayout
- Display itens in a grid that automatically spaces out items with diferent spans

```xaml
<CollectionView
    ItemsSource="{Binding Monkeys}"
    SelectionMode="None">
    <!-- Change ItemsLayout to GridItemsLayout-->
    <CollectionView.ItemsLayout>
        <GridItemsLayout Orientation="Vertical" Span="3" />
    </CollectionView.ItemsLayout>
    <!-- ItemTemplate -->
</CollectionView>
```
## Empty View
- Creates a place holder for the CollectionView while it doesent have any items
