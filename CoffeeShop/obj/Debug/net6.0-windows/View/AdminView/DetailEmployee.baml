   M S B A M L   `   `   `  ����E  ACoffeeShop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:CoffeeShop.View.AdminViewCoffeeShop.View.AdminView  5   	   ;"clr-namespace:CoffeeShop.ViewModelCoffeeShop.ViewModel  5   	   .    (CoffeeShop.View.AdminView.DetailEmployee   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   9local'clr-namespace:CoffeeShop.View.AdminView     5   	   1vm"clr-namespace:CoffeeShop.ViewModel     5   	   _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  67   _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   -   5        $��detailWindow��5   	      
EmployeeVM  � DataContext#  [  5	   	    � Title$ DetailEmployee��5
   	   $	��500��6    $	��550��6-    � AllowsTransparency$
 True��5   	    � WindowStartupLocation$ CenterScreen=�5   	    � WindowStyle$
 None=�5   	   
������  � 
ResizeMode$ NoResize=�5   	   $��16(�5   	   *  $Microsoft.Xaml.Behaviors.Interaction   Triggers 5      +  %Microsoft.Xaml.Behaviors.EventTrigger  5   
      	EventName$ Loaded��6   *  $Microsoft.Xaml.Behaviors.TriggerBase   Actions. 5      2  ,Microsoft.Xaml.Behaviors.InvokeCommandAction  	   Command	 6$   �� *getDetailWindow+
   CommandParameter
 5      ��  �� ElementName$ detailWindow��5        5   
   $ MouseLeftButtonDown��6   . 5        	 6$   �� *MouseLeftButtonDownWindow+
 5      �� $ detailWindow��5      .��5      � $��20q�6    J� Effect 5   
   3  -System.Windows.Media.Effects.DropShadowEffect  5          
BlurRadius$ 30Q�6      ShadowDepth$ 1Q�5!         Opacity$	 0.4Q�5"      5#      .+�5%   
   ��  �� CornerRadius$ 10��6   
�������._�5&   
   �  � RowDefinitions 5'      �� 5(      $��1* �6    �� 5)      $��1* �6    .+�5+      �� $��0��6   .+�5,      �� $��20q�6!    �� Orientation$ 
Horizontal=�6-   .+�5-      � $	��100��6   $	��100��6+   .+�5.      �� $	��100��6%   $	��100��61   $ 50��6>   
������  J� Clip 5/   "   @� 50   &    @� Center$ 50,50&�66    @� RadiusX$ 50Q�6E    @� RadiusY$ 50Q�6R   ._�52   "   �� $��UniformToFill=�6V   ��6(   �� *SelectedEmployee.ImageData+6V   53      �� 54      $��30��6%   $��30��6M    * &MaterialDesignFloatingActionMiniButton#��[ 6Y   $��Right=�6�   $��Bottom=�6�   ��60   �� *
getImage+.��55   "   '  !MaterialDesignThemes.Wpf.PackIcon     Kind$	 Add=�6:   
�������$��24��6X   $��24��6d   56      57      �� 58      $��20 0 0 0q�6%   $	��340��67   .+�59      �� $ 
Horizontal=�6)   $��Center=�6B   .+�5:   "     
���   � J� Opacity$	 0.4Q�6M   $ Account=�6[   $��30��6j   $��30��6v   $��Center=�6�   $��Center=�6�   �� 5;   "   $��Center=�6+   $��10 0 0 0q�6F   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$
 Name��6X   $	��200��6~   $��25(�6�   $��Black"�6�   ��6�   �� *SelectedEmployee.NameEm+6�   5<      �� 5=      $ 
Horizontal=�6)   $��Center=�6B   .+�5>   "   �� $��Center=�6,   $��40 0 0 0q�6G   $��17(�6Y   $��SemiBold"�6g    �� SelectedIndex 6}   �� *!SelectedEmployeeRoleIndexWindow+.@�5?   &   �� $��Staff��63   �� 5@   &   $��Cashier��63   5A   #   5B      5C      5D      �� 5E      $��	20 0 20 0q�6!   $��1��64   $ Vertical=�6A   .+�5F      �� $ 
Horizontal=�6%   $��Center=�6>   .+�5G      �� $��Center=�6(   $��
UserName: ��6C   $��20(�6U   $��DemiBold"�6c   �� 5H      $��Center=�6&   $��20 0 0 0q�6A   $	��300��6~   $��20(�6�   $��Medium"�6�   ��6S   �� *SelectedEmployee.Username+6�   5I      �� 5J      $ 
Horizontal=�6%   $��Center=�6>   .+�5K      �� $��Center=�6(   $��
Password: ��6C   $��20(�6U   $��DemiBold"�6c   �� 5L      $��Center=�6'   $��20(�6i   $	��300��6w   $��Medium"�6�   ��6B   �� *SelectedEmployee.Pass+6�   5M      5N      5O      #  MaterialDesignThemes.Wpf.Card  5Q      $��2��6&   $��10q�5R   &   
�������   UniformCornerRadius$ 10Q�5T   "   .��5U      �� $��10q�6!   $��1��6-   $ Vertical=�6:   .+�5V      �� $ 
Horizontal=�6%   $��Center=�6>   .+�5W      �� $��Center=�6(   $��Gender: ��6C   $��20(�6S   $��DemiBold"�6a   �� 5X      $��Center=�6(   $��20 0 0 0q�6C   $��20(�6U   $��Light"�6c    6v   �� *#!SelectedEmployeeGenderIndexWindow+.@�5Y   "   �� $
��Male��6/   �� 5Z   "   $��Felmale��6/   5[      5\      �� 5]      $ 
Horizontal=�6%   $��Center=�6>   .+�5^      �� $��Center=�6(   $��	Contact: ��6C   $��20(�6T   $��DemiBold"�6b   �� 5_      $��Center=�6&   $��	20 0 20 0q�6A   $	��200��6   $��20(�6�   $��Light"�6�   ��6T   �� *SelectedEmployee.PhoneNum+6�     5`      
���   �$	 0.4Q�6I   $ Phone=�6W   $��25��6d   $��25��6p   $��Center=�6{   $��Center=�6�   5a      �� 5b      $ 
Horizontal=�6%   $��Center=�6>   .+�5c      �� $��Center=�6(   $��Date Birth: ��6C   $��20(�6W   $��DemiBold"�6e   (	  "System.Windows.Controls.DatePicker	  5d      $��20 0 0 0q�6)   $	��250��6q   $��20(�6~   $��Light"�6�    	  SelectedDate 6<   �� *SelectedEmployee.DayOfBirth+6�   5e      �� 5f      $ 
Horizontal=�6%   $��Center=�6>   .+�5g      �� $��Center=�6(   $��	Address: ��6C   $��20(�6T   $��DemiBold"�6b   �� 5h      $��Center=�6&   $��20 0 0 0q�6B   $	��350��6T   $��20(�6�   $��Light"�6�   ��6`   �� *SelectedEmployee.AddressEm+6�   5i      �� 5j      $��10q�6%   $ 
Horizontal=�61   $��Center=�6J   $��Right=�6e   .+�5k      �� $��0 0 20 0q�6%   $��Update��67   
���������6[   �� *UpdateEmployee+�� 5l      $��Cancel��6%   
���������6I   �� *closeDetailEmployeeWindow+5n      5o      5p      5q      5r      5s      5t      