   M S B A M L   `   `   `  ����E  ACoffeeShop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:CoffeeShop.View.AdminViewCoffeeShop.View.AdminView  5   	   '    !CoffeeShop.View.AdminView.AddFood   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  6R   :d2http://schemas.microsoft.com/expression/blend/2008  5   	   Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5   	   3local'clr-namespace:CoffeeShop.View.AdminView  5   	   -   5        $��AddFoodWindow��5	   	     � AllowsTransparency$
  True��5
   	    � WindowStartupLocation$ CenterScreen=�5   	    � WindowStyle$
 None=�5   	   
������  � 
ResizeMode$ NoResize=�5   	   $��16(�5   	    
  MenuVM � DataContext# [  5   	    � Title$ AddFood��5   	   $	��350��6   $	��550��6&   *  $Microsoft.Xaml.Behaviors.Interaction   Triggers 5      +  %Microsoft.Xaml.Behaviors.EventTrigger  5   
      	EventName$ MouseLeftButtonDown��6   *  $Microsoft.Xaml.Behaviors.TriggerBase   Actions. 5      2  ,Microsoft.Xaml.Behaviors.InvokeCommandAction  	   Command	 6$   �� *MouseLeftButtonDownWindow+
   CommandParameter
 5      ��  �� ElementName$ AddFoodWindow��5        5   
   $ Loaded��6   . 5        	 6$   �� *setAddFoodWindow+
 5      �� $ AddFoodWindow��5      .��5      � $��20q�6    J� Effect 5   
   3  -System.Windows.Media.Effects.DropShadowEffect  5          
BlurRadius$ 30Q�6      ShadowDepth$ 1Q�5!         Opacity$	 0.4Q�5"      5$      .+�5'   
   �� 
������� �� CornerRadius$ 10��6$   ._�5(      �  � ColumnDefinitions 5)      �� 5*      $	��200 �6'   �� 5+      $��1* �6'   .+�5-      � $��0��6   .+�5.      �� 
�������$ 	10 0 0 10��60   ._�5/      �� ��6    �� *NewProductImage+50      �� 51      $��10q�6D    * &MaterialDesignFloatingActionMiniButton#��[ 6P   $��Bottom=�6�   $��Right=�6�   ��6   �� *getImageNewProduct+.��52      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$	 Add=�62   $��30��6=   $��20��6I   
�������6T   53      54      � 55      $��1��6    � RowDefinitions 56      �� 57      $��60 �6(   �� 58      $��1* �6(   �� 59      $��40 �6(   �� 5:      $��40 �6(   �� 5;      $��50 �6(   .+�5=      �� )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ NameFood��6   $��20 0 0 0q�5?      $	��200��5@      $��25(�5A      $��Black"�5B      $
��Left=�5C      $��Center=�5D      ��5>      �� *NewProductName+5D      �� 5E      $��1��6   
�������$
��20 0q�6=   $ 10��6K   $��1q�6]   
���   �._�5F      �� $��1��5G      $	��250��5H       �� TextWrapping$
 Wrap=�5I      $
��10 0q�5J      $	��120��5K      $��14(�5L      $��Light"�5M      $��Center=�5N      $
��Left=�5O      " �� VerticalScrollBarVisibility$
 Auto=�5P      $ Description��5Q      ��5F      �� *NewProductDescription+5Q      5R      �� 5S      $��2��6!   $
��20 0q�6.    �� Orientation$ 
Horizontal=�6<   $��Center=�6U   .+�5T      �� $��Center=�6$   $��Type: ��6?   $��15(�6M   $��DemiBold"�6[   �� 5U      $	��100��6#   $��15(�6/   $��Light"�6=   ��6P   �� *ListTypeString+ �� SelectedIndex 6w   �� *NewProductType+ �� Mode$ TwoWay=�5V      �� 5W      $��3��6!   $
��20 0q�6.   $ 
Horizontal=�6<   $��Center=�6U   .+�5X      �� $��Center=�6$   $��Price: ��6?   $��15(�6N   $��DemiBold"�6\   �� 5Y      $��	20 0 10 0q�6"   $��Center=�65   $��15(�6q   $	��100��6   $
��Bold"�6�   
��� �����6P   �� *NewProductPrice+6�   �� 5Z      $��Center=�6$   $	��VND��6?   $��15(�6J   $��DemiBold"�6X   5[      �� 5\      $��4��6!   $ 
Horizontal=�6.   $��Center=�6G   $��Right=�6b   $��0 0 20 0q�6   .+�5]      �� $��0 0 10 0q�6!   $	��Add��63   $��25��6A   ��6M   �� *	addFood+�� 5^      $��Cancel��6!   $��25��62   ��6>   �� *exit+5_      5`      5b      5c      5d      5f      