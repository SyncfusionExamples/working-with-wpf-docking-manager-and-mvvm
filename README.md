# Working with WPF DockingManager and MVVM

This sample demonstrates how to use **Syncfusion DockingManager** in a WPF application following the **MVVM pattern**. It shows how to create an MVVM adapter for DockingManager to manage docking windows without breaking the MVVM principles.

## Features in This Sample
- **MVVM Integration**: Implements DockingManager in a WPF application using MVVM.
- **Adapter Pattern**: Provides an adapter to handle DockingManager operations in a ViewModel-friendly way.
- **Dynamic Docking Windows**: Allows adding and managing docking windows programmatically.
- **Document Container Support**: Enables tabbed document interface using `UseDocumentContainer` property.

## Key Concepts
- **DockingManager**: A layout control that allows docking, floating, and tabbed windows.
- **MVVM Adapter**: Bridges the gap between DockingManager and ViewModel by exposing commands and properties.

## XAML Overview
```xml
<UserControl x:Class="DockingAdapterMVVM.DockingAdapter"
             xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
             xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
             xmlns:syncfusion="http://schemas.syncfusion.com/wpf">
    <Grid>
        <syncfusion:DockingManager x:Name="PART_DockingManager"
                                   UseDocumentContainer="True"
                                   ActiveWindowChanged="PART_DockingManager_ActiveWindowChanged_1" />
    </Grid>
</UserControl>
```

## How It Works
1. The `DockingManager` is placed inside a `UserControl`.
2. An MVVM adapter is implemented to handle docking operations via commands and bindings.
3. The `UseDocumentContainer` property enables tabbed document interface for child windows.

## Benefits of MVVM with DockingManager
- Decouples UI logic from business logic.
- Improves testability and maintainability.
- Allows dynamic layout management through ViewModel.

## Documentation
For more details, refer to the official Syncfusion documentation:  
[DockingManager MVVM Pattern](https://help.syncfusion.com/wpf/docking/pattern-and-practices#mvvm)

