   M S B A M L   `   `   `  ����  
CoffeeShop-    'CoffeeShop.View.CashierView.CashierView   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  6R   -   5        $��cashierWindow��5	   	     � Title$  CashierView��5   	   $��550px��5
   	   $	��900��5   	    � AllowsTransparency$
 True��5   	    � WindowStartupLocation$ CenterScreen=�5   	    � WindowStyle$
 None=�5   	   
������  � 
ResizeMode$ 	CanResize=�5   	   $��16(�5   	      	CashierVM � DataContext# [  5   	     MaterialDesignFont#���  5   	   *  $Microsoft.Xaml.Behaviors.Interaction   Triggers 5      +  %Microsoft.Xaml.Behaviors.EventTrigger  5   
      	EventName$ Loaded��6   *  $Microsoft.Xaml.Behaviors.TriggerBase   Actions. 5      2  ,Microsoft.Xaml.Behaviors.InvokeCommandAction  	   Command	 6$   �� *setContentFrame+
   CommandParameter
 5      ��  �� ElementName$ 	mainFrame��5        5   
   $ Loaded��6   . 5        	 6$   �� *setCashierWindow+
 5      �� $ cashierWindow��5      .��5      ��  �� CornerRadius$ 10��6   
�������._�5    
   �  � ColumnDefinitions 5!      �� 5"      $	��100 �6#   �� 5#      $��1* �6#   .+�5%      � $��0��6   .+�5&      �� 
�������$ 	10 0 0 10��5'      $��0 0 1 0q�5(      
�������._�5*      �  � RowDefinitions 5+      �� 5,      $��1* �6,   �� 5-      $��5* �6,   �� 5.      $��1* �6,   .+�51      �� ._�52      �� $2��,/COFFEESHOP;component/Resources/Img/logo.png��6$   53      �� 54      $��1��6%   $��Center=�55      $��Center=�56      .+�57      �� -   5         ��Name$ btnPos��57   %     MaterialDesignFlatButton#��[ 59      $��60��5:      $��60��5;      $��0q�5<      $
��0 10q�5=      ��58      �� *	posView+.��5>   "   �� $��Center=�6-   $��Center=�5?   %   .+�5@   &   '  !MaterialDesignThemes.Wpf.PackIcon  
���   � J� Opacity$	 0.4Q�6Q      Kind$ 
NetworkPos=�6_   $��30��6q   $��30��6}   $��Center=�6�   $��Center=�6�   �� 5A   &   $	��POS��60   
���   �$	 0.4Q�5C   (   $��11(�5D   (   $��Center=�5E   (   5F   #   5G      �� 5I      #��[ 6%   $��60��5J      $��60��5K      $��0q�5L      $
��0 10q�5M      ��5N      �� *historyView+.��5O   "   �� $��Center=�6-   $��Center=�5P   %   .+�5Q   &     
���   �$	 0.4Q�6Q   $ ClockTimeFourOutline=�6_   $��30��6{   $��30��6�   $��Center=�6�   $��Center=�6�   �� 5R   &   $��History��60   
���   �$	 0.4Q�5T   (   $��10(�5U   (   $��Center=�5V   (   5W   #   5X      5Y      �� 5[      $��2��6!   #��[ 5]      $��60��5^      $��60��5_      $��0q�5`      $
��0 10q�5a      ��5\      �� *logOut+.��5b      �� $��Center=�6)   $��Center=�5c   !   .+�5d   "     
���   �$	 0.4Q�6M   $ Logout=�6[   $��30��6i   $��30��6u   $��Center=�6�   $��Center=�6�   �� 5e   "   $��Logout��6,   
���   �$	 0.4Q�5g   $   $��10(�5h   $   $��Center=�5i   $   5j      5k      5l      5m      5n      �� 5o      $��1��6   
�������$ 	0 10 10 0��5q      � 5r      $��1��6    5s      �� 5t      $��35 �6$   �� 5u      $��1* �6$   .+�5w      ��  �� Padding$ 0 0 0 5q�6   $��0��6+   
�������$��0 0 0 1q�6P   6l   �� 5x      -   5         ��Name$ 
ControlBar��5x      $��0��5y       �� Orientation$ 
Horizontal=�5z      $��RightToLeft=�5{      
������ $��0 0 10 0q�5}      .+�5      �� #��[ 6   $��35��5�      $��20��5�      $	��5 0q�5�      $��0 5 0 0q�5�      ��5�      �� *exitCashier+.��5�        
���   �$	 0.4Q�6E   $ Close=�6S   $��20��6`   $��20��6l   $��Center=�6w   $��Center=�6�   5�      �� 5�      #��[ 6   $��35��5�      $��20��5�      $	��5 0q�5�      $��0 5 0 0q�5�      ��5�      �� *minimizeCashier+.��5�        
���   �$	 0.4Q�6E   $ Minimize=�6S   $��20��6c   $��20��6o   $��Center=�6z   $��Center=�6�   5�      5�       � 5�      -   5        $��	mainFrame��5�      $��2��5�        � NavigationUIVisibility$ Hidden=�5�   %   5�      5�      5�      5�      5�      