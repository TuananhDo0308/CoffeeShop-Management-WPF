   M S B A M L   `   `   `  ����E  ACoffeeShop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:CoffeeShop.View.AdminViewCoffeeShop.View.AdminView  5      2    ,CoffeeShop.View.AdminView.EmployeeManagement   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      9local'clr-namespace:CoffeeShop.View.AdminView     5      _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  6a   -   5        $��employeePage��5	         
EmployeeVM  � DataContext#  [  5
       N� Title$ EmployeeManagement��5      *  $Microsoft.Xaml.Behaviors.Interaction   Triggers 5      +  %Microsoft.Xaml.Behaviors.EventTrigger  5   
      	EventName$ Loaded��6   *  $Microsoft.Xaml.Behaviors.TriggerBase   Actions. 5      2  ,Microsoft.Xaml.Behaviors.InvokeCommandAction     Command 6$   �� *	firstLoad+   CommandParameter 5      ��  �� ElementName$ employeePage��5        5   
   $ Loaded��6   . 5         6$   �� *getListBoxEmployee+ 5      �� $ listBox��5      .��5      � 
������� � RowDefinitions 5   
   �� 5      $��90 �6   �� 5      $��5* �6   .+�5   
   � $��0��6   .+�5!      �� 
�������$��0 0 0 1q�6-   ._�5"      � 	 � ColumnDefinitions	 5#      �� 5$      $��3* �6+   �� 5%      $	��290 �6+   .+�5(      � $��0��6   $
��Left=�5)      $��Center=�5*      .+�5+      �� $��	30 0 20 0q�6%   $	��600��68   
 �� Orientation$
 
Horizontal=�6D   .+�5,      �� 
������� �� CornerRadius$ 20��68   $	��350��6J   $��40��6V   $
��Left=�6b   $��Bottom=�6}   
���   �$��1q�6�   ._�5-   "   �� $
 
Horizontal=�6-   .+�5.   &   '  !MaterialDesignThemes.Wpf.PackIcon  $��	20 0 10 0q�6>   
���   � J� Opacity$	 0.4Q�6d      Kind$ 
FindInPage=�6r   $��20��6�   $��20��6�   $��Center=�6�   $��Center=�6�   �� 5/   &   -   5        $��	searchBox��5/   �   $
��Left=�6.   $��0 10 0 0q�6I   $��15(�6\   $��Medium"�6j   $	��Top=�6   $��41��6�   $	��300��6�   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Search employee by name��6  ��6�   �� *	SearchBox+ �� UpdateSourceTrigger$ PropertyChanged=�.��6:   50   *     51   .   $ TextChanged��6=   . 52   2      6H   �� *findEmployee+53   /   .��54   B   55   '   56   #   57      58      59      � 5:      $��1��6   $��Center=�5;      $��Center=�5<      .+�5=      �� 
�������$	��290��69   $��90��6E   $��1 0 0 0q�6Q   ._�5>      �� $
 
Horizontal=�6)   $��Center=�5?   )   $��Center=�5@   )   .+�5A   "   �� $	��Top=�6)   $
��Left=�6A   
������ $��30��6u   $��30��6�   $ 10000��6�    J� Clip 5B   &   @� 5C   *    @� Center$ 15,15&�6:    @� RadiusX$ 15Q�6I    @� RadiusY$ 15Q�6V   ._�5E   &   �� $��UniformToFill=�6N   ��6,   �� *User.ImageData+6N   5F   #   �� 5H   "   $��10 0 0 0q�6-   $
 Vertical=�5I   -   $��Center=�5J   -   $��Center=�5K   -   .+�5L   &   �� -   5         ��Name$
 Name��5L   T   $��15(�60   $��DemiBold"�6>   ��6b   �� *User.NameEm+�� 5M   &   -   5        $
 Role��5M   Q   $��12(�60   $��Light"�6>   ��6_   �� *User.NameRole+5N   #   5O      5P      5Q      5R      5S      5T      � 5V   
   $��1��6   ���#f8f8f8.+�5W      � $��0��6    5X      �� 5Y      $��60 �6$   �� 5Z      $	��13* �6$   .+�5\      � $��0��6   .+�5]      �� $��0 0 50 0q�6   $��Center=�6/   $��Right=�6J   $	��Add��6f   ��6t   �� *addNewEmployee+5^      � 5_      $��30 0 0 0q�6   $��1��6)   $��Stretch=�66   $	��Top=�6T   .+�5`      �� -   5        $��listBox��5`   �   $
��Left=�6   $��Center=�6�   $��Center=�6�   ��69   �� *ListEmployees+ �� SelectedItem 6_   �� *SelectedEmployee+��5a      �� 5b      .R�5c   "   A�  A� Columns$ 3��6.   5d      ��5f      �� 5g      .R�5h   "   #  MaterialDesignThemes.Wpf.Card  $	��350��67   $	��270��6C   .��5i   &   � $��10q�6+    5j   *   �� 5k   .   $	��120 �6<   �� 5l   .   $��1* �6<   .+�5n   *   � $��0��6/   $	��Top=�6<   $��Stretch=�6T   	 5o   .   �� 5p   2   $��2* �6C   �� 5q   2   $��1* �6C   .+�5s   .   �� $��	10 10 0 0q�69   $
 Vertical=�6L   $	��Top=�6c   $��Stretch=�6{   .+�5t   2   �� $	��Top=�69   $
��Left=�6Q   
������ $��50��6�   $��50��6�   $ 10000��6�    5u   6   @� 5v   :   $ 25,25&�6J   $ 25Q�6Y   $ 25Q�6f   ._�5x   6   �� $��UniformToFill=�6Y   ��6<   �� *	ImageData+6Y   5y   3   �� 5z   2   $��20(�6<   $
��Bold"�6J   ��6\   �� *NameEm+�� 5{   2   $��20(�6<   $��Light"�6J   ��6]   �� *
NameRole+5|   /   �� 5}   .   $
 
Horizontal=�69   $��	0 10 10 0q�6R   $	��Top=�6e   $��Right=�6}   $��1��6�   .+�5~   2     $ Delete=�6J   
�������$��Center=�5�   L   $��Center=�5�   L   $��30��5�   L   $��30��5�   L   $��5 0 0 0q�5�   L   $��0q�5�   L    5�   6     5�   :   $ MouseLeftButtonDown��6I   . 5�   >      6T   �� *DataContext.removeEmployee+$ listBox��5�   ;   5�   3     5�   2   $��Center=�6J   $��Center=�6g   $
 Menu=�6�   
�������$��30��5�   H   $��30��5�   H   $��0q�5�   H    5�   6     5�   :   $ MouseLeftButtonDown��6I   . 5�   >      6T   �� *&$DataContext.openDetailEmployeeWindow+$ listBox��5�   ;   5�   3   5�   /   5�   +     5�   *   $��5q�6>   $��1��6I   $��Stretch=�6V   .��5�   .   �� $��10q�69   .+�5�   2   �� $��0 5 0 5q�6=   $
 
Horizontal=�6N   $��Center=�6g   $
��Left=�6�   .+�5�   6   �� $��Center=�6@   $��
Date Birth��6[   $��18(�6m   $��DemiBold"�6{   �� 5�   6   $��10 0 0 0q�6@   
���   �$��18(�6�   $��Light"�6�   ��6f   �� *
DayOfBirth+6�   5�   3   �� 5�   2   $��0 5 0 5q�6=   $
 
Horizontal=�6N   $��Center=�6g   $
��Left=�6�   .+�5�   6   �� $��Center=�6@   $��
Username: ��6[   $��18(�6m   $��DemiBold"�6{   �� 5�   6   $��10 0 0 0q�6@   
���   �$��18(�6   $��Light"�6�   ��6e   �� *
Username+6�   5�   3   �� 5�   2   $��0 5 0 5q�6=   $
 
Horizontal=�6N   $��Center=�6g   $
��Left=�6�   .+�5�   6   �� $��Center=�6@   $��	Address: ��6[   $��18(�6l   $��DemiBold"�6z   �� 5�   6   $��10 0 0 0q�6@   
���   �$��18(�6�   $��Light"�6�   ��6e   �� *	AddressEm+6�   5�   3   5�   /   5�   +   5�   '   5�   #   5�      5�      5�      5�      5�      5�      5�      