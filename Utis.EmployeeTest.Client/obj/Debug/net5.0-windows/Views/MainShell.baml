   M S B A M L   `   `   `  ����S  OUtis.EmployeeTest.Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:Utis.EmployeeTest.ClientUtis.EmployeeTest.Client  5   	   e7clr-namespace:Utis.EmployeeTest.Client.Views.Converters)Utis.EmployeeTest.Client.Views.Converters  5   	   .    (Utis.EmployeeTest.Client.Views.MainShell   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   8local&clr-namespace:Utis.EmployeeTest.Client     5   	   N
converters7clr-namespace:Utis.EmployeeTest.Client.Views.Converters     5   	   b ^MaterialDesignThemes.Wpf, Version=3.2.0.1979, Culture=neutral, PublicKeyToken=df2a72020bd7962a;mde1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Title$  
MainWindow��5
   	   $	��450��6   $	��800��6)    � 	Resources 5      H  BUtis.EmployeeTest.Client.Views.Converters.EnumDescriptionConverter   EnumDescriptionConverter��%   &	          5   
   6.   5      .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      .+�5   
   � $��0��6    � IsIndeterminate$
 True��5      $��Bottom=�5      y�5      �� *	IsLoading+   BooleanToVisibilityConverter �� 	Converter# [ �� 5   
   $��0��6    �� Orientation$ 
Horizontal=�5      $��5q�5      .+�5       ��   MaterialDesignFlatButton#��[ 5!      
���   � � ToolTip$ Добавить��5#      ��5       0  *MaterialDesignThemes.Wpf.PackIconExtension     Kind$ TableRowPlusAfter=���5$      �� *
AddCommand+�� 5'      #��[ 5(      
���   �$ Удалить��5*      ��5'        $ TableRowRemove=�{�5+      �� *SelectedWorker+  notNullBooleanConverter# [ ��5,      �� *RemoveCommand+�� 5/      #��[ 50      
���   �$  Редактировать��52      ��5/        $
 Edit=�{�53      �� *SelectedWorker+# [ ��54      �� *EditCommand+�� 56      $��1��6   
���iii�$��10q�58      �� 5;      #��[ 5<      
���   �$ Обновить��5>      ��5;        $ Refresh=���5?      �� *RefreshCommand+5@      &   System.Windows.Controls.DataGrid  5C   
   $��1��6      AutoGenerateColumns$ False��5D      	   
IsReadOnly$
	 True��5E      
   SelectionMode$
 Single=�5F         SelectionUnit$ FullRow=�5G         CanUserAddRows$ False��5H       �� SelectedItem 5I      �� *SelectedWorker+��5J      �� *	Workers+   Columns 5L      0  *System.Windows.Controls.DataGridTextColumn  5N      ,  &System.Windows.Controls.DataGridColumn   Header$ Фамилия��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 5O   %   �� *	Surname+  5P      $ Имя��6%    5Q   %   �� *Name+  5R      $ Отчество��6%    5S   %   �� *
Patronym+  5T      $ Дата рождения��6%    5U   %   �� *	BirthDate+ �� StringFormat$ 
dd-MM-yyyy��  5W      $ Пол��6%    5X   %   �� *Sex+# [  4  .System.Windows.Controls.DataGridCheckBoxColumn  5Z      $ Наличие детей��6)    5[   )   �� *HasChildren+5^      5_      5`      