   M S B A M L   `   `   `  ����E  ACoffeeShop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:CoffeeShop.View.AdminViewCoffeeShop.View.AdminView  5      +    %CoffeeShop.View.AdminView.HistoryPage   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      9local'clr-namespace:CoffeeShop.View.AdminView     5      _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  6P   -   5        $��historyPage��5	         	HistoryVM  � DataContext#  [  5
       N� Title$ HistoryPage��5      *  $Microsoft.Xaml.Behaviors.Interaction   Triggers 5      +  %Microsoft.Xaml.Behaviors.EventTrigger  5   
      	EventName$ Loaded��6   *  $Microsoft.Xaml.Behaviors.TriggerBase   Actions. 5      2  ,Microsoft.Xaml.Behaviors.InvokeCommandAction     Command 6$   �� *	firstLoad+   CommandParameter 5      ��  �� ElementName$ listBox��5      .��5      � 
������� � RowDefinitions 5   
   �� 5      $��90 �6   �� 5      $��5* �6   .+�5   
   � $��0��6   .+�5      �� 
�������$��0 0 0 1q�6-   ._�5      � 	 � ColumnDefinitions	 5       �� 5!      $��3* �6+   �� 5"      $	��290 �6+   .+�5%      � $��0��6   $
��Left=�5&      $��Center=�5'      .+�5(      �� $��	30 0 20 0q�6%   $	��600��68   
 �� Orientation$
 
Horizontal=�6D   .+�5)      �� 
������� �� CornerRadius$ 20��68   $	��350��6J   $��40��6V   $
��Left=�6b   $��Bottom=�6}   
���   �$��1q�6�   ._�5*   "   �� $
 
Horizontal=�6-   .+�5+   &   '  !MaterialDesignThemes.Wpf.PackIcon  $��	20 0 10 0q�6>   
���   � J� Opacity$	 0.4Q�6d      Kind$ 
FindInPage=�6r   $��20��6�   $��20��6�   $��Center=�6�   $��Center=�6�   �� 5,   &   -   5        $��	searchBox��5,   �   $
��Left=�6.   $��0 10 0 0q�6I   $��15(�6\   $��Medium"�6j   $	��Top=�6   $��41��6�   $	��300��6�   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$$ Search bill by customer's name��6   ��6�   �� *	SearchBox+ �� UpdateSourceTrigger$ PropertyChanged=�.��6@   5-   *     5.   .   $ TextChanged��6=   . 5/   2      6H   �� *findNameCus+50   /   .��51   B   52   '   53   #   54      (  "System.Windows.Controls.DatePicker  55      $	��140��6)   $��20 0 0 0q�65   $��15(�6I   $��Medium"�6W   $ 	Pick Date��57   *    ( $MaterialDesignFloatingHintDatePicker#��[ 58   *      SelectedDate 56   *   �� *
FilterDate+$ PropertyChanged=� 59   "     5:   &   $ SelectedDateChanged��65   . 5;   *      6@   �� *filterByDate+5<   '   5>      5A      5B      � 5C      $��1��6   $��Center=�5D      $��Center=�5E      .+�5F      �� 
�������$	��290��69   $��90��6E   $��1 0 0 0q�6Q   ._�5G      �� $
 
Horizontal=�6)   $��Center=�5H   )   $��Center=�5I   )   .+�5J   "   �� $	��Top=�6)   $
��Left=�6A   
������ $��30��6u   $��30��6�   $ 10000��6�    J� Clip 5K   &   @� 5L   *    @� Center$ 15,15&�6:    @� RadiusX$ 15Q�6I    @� RadiusY$ 15Q�6V   ._�5N   &   �� $��UniformToFill=�6N   ��6,   �� *User.ImageData+6N   5O   #   �� 5P   "   $��10 0 0 0q�6-   $
 Vertical=�5Q   -   $��Center=�5R   -   $��Center=�5S   -   .+�5T   &   �� -   5         ��Name$
 Name��5T   T   $��15(�60   $��DemiBold"�6>   ��6b   �� *User.NameEm+�� 5U   &   -   5        $
 Role��5U   Q   $��12(�60   $��Light"�6>   ��6_   �� *User.NameRole+5V   #   5W      5X      5Y      5Z      5[      5\      � 5^   
   $��1��6   .+�5_      #  MaterialDesignThemes.Wpf.Card  
�������$��20,20,20,20q�5`   "      UniformCornerRadius$ 5Q�5a   "   .��5b      �� .+�5c      �� -   5         ��Name$ listBox��5c      $
|�True��5e      $	��578��5g      ��5d      �� *Bills+ �� SelectedItem 5f      �� *SelectedBill+ �� View 5i      �� 5j      .P�5k   "   �� $��OrderID��61    �� Width$	 140��5l   1    �� CellTemplate 5m   &   �� 5n   *   .R�5o   .   �� $��18(�5p   8   ��5o   8   �� *IdBill+5p   8   5q   +   5s   #   �� 5t   "   $��Customer's Name��61   $	 250��5u   1    5v   &   �� 5w   *   .R�5x   .   �� $��30,0,0,0q�5y   8   $��18(�5z   8   ��5x   8   �� *NameCustomer+5z   8   5{   +   5}   #   �� 5~   "   $��Staff's Name��61   $	 250��5   %    5�   &   �� 5�   *   .R�5�   .   �� $��20,0,0,0q�5�   ,   $��18(�5�   ,   ��5�   8   �� *	StaffName+5�   ,   5�   +   5�   #   �� 5�   "   $
��Date��61   $	 150��6?    5�   &   �� 5�   *   .R�5�   .   �� $��20,0,0,0q�5�   8   $��18(�5�   8   ��5�   8   �� *	DayBill+5�   8   5�   +   5�   #   �� 5�   "   $��Price (VND)��61   $	 150��5�   1    5�   &   �� 5�   *   .R�5�   .   �� $��40,0,0,0q�5�   8   $��18(�5�   8   ��5�   8   �� *Price+5�   8   5�   +   5�   #   �� 5�   "   $��Status��61   $	 200��5�   2    5�   &   �� 5�   *   .R�5�   .   �� $��40,0,0,0q�5�   8   $��18(�5�   8   ��5�   8   �� *
StatusBill+5�   8   5�   +   5�   #   �� 5�   "    5�   &   �� 5�   *   .R�5�   .   �� $
 
Horizontal=�69   .+�5�   2   �� $��Detail��69     MaterialDesignFlatButton#��[ 5�   9   ��5�   9   �� *DataContext.detailView+$ listBox��5�   /   5�   +   5�   #   5�      5�      5�      5�      5�      5�      5�      