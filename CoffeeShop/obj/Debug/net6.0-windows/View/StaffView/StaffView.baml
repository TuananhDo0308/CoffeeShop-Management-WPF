   M S B A M L   `   `   `  ����E  ACoffeeShop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:CoffeeShop.View.StaffViewCoffeeShop.View.StaffView  5   	   )    #CoffeeShop.View.StaffView.StaffView   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   9local'clr-namespace:CoffeeShop.View.StaffView     5   	   _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   
   _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  6S   -   5        $��StaffWindow��5
   
     � Title$  CashierView��5	   
   $	��600��5   
   $
��1000��5   
    � AllowsTransparency$
 True��5   
    � WindowStartupLocation$ CenterScreen=�5   
    � WindowStyle$
 None=�5   
   
������  � 
ResizeMode$ 	CanResize=�5   
      StaffVM � DataContext# [  5   	   $��16(�5   
   *  $Microsoft.Xaml.Behaviors.Interaction   Triggers 5      +  %Microsoft.Xaml.Behaviors.EventTrigger  5   
      	EventName$ Loaded��6   *  $Microsoft.Xaml.Behaviors.TriggerBase   Actions. 5      2  ,Microsoft.Xaml.Behaviors.InvokeCommandAction  	   Command	 6$   �� *	firstLoad+
   CommandParameter
 5      ��  �� ElementName$ StaffWindow��5      .��5      ��  �� CornerRadius$ 10��6   
�������._�5   
   �  � RowDefinitions 5       �� 5!      $��35 �6    �� 5"      $��90 �6    �� 5#      $��1* �6    .+�5%      ��  �� Padding$ 0 0 0 5q�6   $��0��6'   
�������$��0 0 0 1q�6L   6h   �� 5&      -   5         ��Name$ 
ControlBar��5&      $��0��5'   	    �� Orientation$ 
Horizontal=�5(   	   $��RightToLeft=�5)   	   
������ $��0 0 10 0q�5+   	   .+�5,      ��   MaterialDesignFlatButton#��[ 6   $��35��5-   	   $��20��5.   	   $	��5 0q�5/   	   $��0 5 0 0q�50   	   ��51   	   �� *closeWindow+.��52      '  !MaterialDesignThemes.Wpf.PackIcon  
���   � J� Opacity$	 0.4Q�6A      Kind$ Close=�6O   $��20��6\   $��20��6h   $��Center=�6s   $��Center=�6�   53      �� 54      #��[ 6   $��35��55   	   $��20��56   	   $	��5 0q�57   	   $��0 5 0 0q�58   	   ��59   	   �� *minimizeWindow+.��5:        
���   �$	 0.4Q�6A   $ Minimize=�6O   $��20��6_   $��20��6k   $��Center=�6v   $��Center=�6�   5;      5<      � 5=      $��1��6   .+�5?      �� 
�������$��0 0 0 1q�61   ._�5@      �  � ColumnDefinitions 5A      �� 5B      $��3* �6/   �� 5C      $	��290 �6/   .+�5E      �� $��0��6<   $��Center=�6L   $
��Left=�6g   $��Log Out��6�   
�������$��50 0 0 0q�6�   ��6!   �� *logOut+6�   � 5F      $��1��6   $��Center=�5G      $��Center=�5H      .+�5I      �� 
�������$	��290��6=   $��90��6I   ._�5J   "   �� $ 
Horizontal=�6-   $��Center=�5K   '   $��Center=�5L   '   .+�5M   &   �� $	��Top=�6-   $
��Left=�6E   
������ $��30��6y   $��30��6�   $ 10000��6�    J� Clip 5N   *   @� 5O   .    @� Center$ 15,15&�6>    @� RadiusX$ 15Q�6M    @� RadiusY$ 15Q�6Z   ._�5Q   *   �� $��UniformToFill=�6R   ��60   �� *User.ImageData+6R   5R   '   �� 5S   &   $��10 0 0 0q�61   $ Vertical=�5T   +   $��Center=�5U   +   $��Center=�5V   +   .+�5W   *   �� -   5         ��Name$
 Name��5W   X   $��15(�64   $��DemiBold"�6B   ��6f   �� *User.NameEm+�� 5X   *   -   5        $
 Role��5X   U   $��12(�64   $��Light"�6B   ��6c   �� *User.NameRole+5Y   '   5Z   #   5[      5\      5]      5^      5_      �� 5a      $ 0 0 10 10  ��6   $��2��60   ���#f8f8f8._�5b      � $��0��6   .+�5c      �� -   5        $��listBox��5f      $��10q�5c      $��Stretch=�5g      $��Stretch=�5h      ��5d      �� *Bills+ �� SelectedItem 5e      �� *SelectedBill+��5j      �� 5k      .R�5l   "   $�  $� Orientation$ 
Horizontal=�69   5m      ��5p      �� 5q       �� 
TargetType" ��6.   .R�5r   "   �� $
��Auto=�6/   $��Disabled=�6T   .��5s   &   �� 5t   #   5u      ��5w      �� 5x      .R�5y   "   � $��20q�6'    J� Effect 5z   &   3  -System.Windows.Media.Effects.DropShadowEffect  5{   *      
BlurRadius$ 30Q�6;      ShadowDepth$ 1Q�5|         Opacity$	 0.4Q�5}      5~   +   .+�5�   &   �� 
�������$ 10��6@   ._�5�   *   �  5�   .   �� 5�   2   $��40 �6@   �� 5�   2   $��70 �6@   �� 5�   2   $	��400 �6@   �� 5�   2   $��50 �6@   .+�5�   .   � $��0��63   $��Center=�6@   $
��Left=�6[   $��20 0 0 0q�6v   .+�5�   2   �� $ 
Horizontal=�6=   .+�5�   6   �� $��Bill ID:  #��6@   $��18(�6S   $��SemiBold"�6a   
��� ���6w   �� 5�   6   $��18(�6X   
��� ���$��SemiBold"�6z   ��6@   �� *IdBill+6z   5�   3   5�   /   �� 5�   .   $��1��69   $��20 5 0 0q�6F   $ Vertical=�6X   $	��Top=�6o   $
��Left=�6�   $	��250��6�   .+�5�   2   �� $ 
Horizontal=�6=   .+�5�   6   �� $��Name: ��6@   $��18(�6N   $��SemiBold"�6\   �� 5�   6   $��20 0 0 0q�6@   $��18(�6p   $��Light"�6~   ��6R   �� *NameCustomer+6~   5�   3   �� 5�   2   $��0 10 0 0q�6=   $ 
Horizontal=�6O   .+�5�   6   �� $��Date: ��6@   $��18(�6N   $��SemiBold"�6\   �� 5�   6   $��20 0 0 0q�6@   $��18(�6k   $��Light"�6y   ��6R   �� *	DayBill+6y   5�   3   5�   /   �� 5�   .     ��Name$  listBox��6O   $��2��67   $��5q�6D   $
|�True��5�   7   $��Stretch=�5�   7   $��Stretch=�5�   7   ��5�   7   �� *
ListItem+! �� View! 5�   2   �� 5�   6   .P�5�   :   �� $��Drinks��6I   " �� Width$	" 150��5�   I   # �� CellTemplate# 5�   >   �� 5�   B   .R�5�   F   �� $��15(�5�   P   ��5�   P   �� *Name+5�   P   5�   C   5�   ;   �� 5�   :   $��Number��6I   $" 60��5�   K   # 5�   >   �� 5�   B   .R�5�   F   �� $��15(�5�   P   ��5�   P   �� *Number+5�   P   5�   C   5�   ;   5�   7   5�   /   � 5�   .   $��3��63   .+�5�   2   �� $��Center=�5�   9   $��Right=�5�   9   $��0 0 20 0q�5�   9   $
��Done��5�   9   
���������5�   9   �� *DataContext.doneButton+$ �� RelativeSource$ �� % �� AncestorType"% ��5�   9   5�   /   5�   +   5�   '   5�   #   5�      5�      5�      5�      5�      5�      5�      