   M S B A M L   `   `   `  ����E  ACoffeeShop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:CoffeeShop.View.AdminViewCoffeeShop.View.AdminView  5      (    "CoffeeShop.View.AdminView.MenuPage   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      9local'clr-namespace:CoffeeShop.View.AdminView     5      _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  6P    
  MenuVM  � DataContext#  [  5	       N� Title$ MenuPage��5      *  $Microsoft.Xaml.Behaviors.Interaction   Triggers 5      +  %Microsoft.Xaml.Behaviors.EventTrigger  5   
      	EventName$ Loaded��6   *  $Microsoft.Xaml.Behaviors.TriggerBase   Actions. 5      2  ,Microsoft.Xaml.Behaviors.InvokeCommandAction     Command 6$   �� *	firstLoad+   CommandParameter 5      ��  �� ElementName$ Pospage��5        5   
   $ Loaded��6   . 5         6$   �� *getFilterBox+ 5      �� $ 	filterBox��5        5   
   $ Loaded��6   . 5         6$   �� *
getListBox+ 5      �� $ listBox��5        5   
   $ Loaded��6   . 5         6$   �� *getSearchBox+ 5      �� $ 	searchBox��5      .��5      � 
������� � RowDefinitions 5    
   �� 5!      $��90 �6   �� 5"      $��5* �6   .+�5%   
   � $��0��6   .+�5'      �� 
�������$��0 0 0 1q�6-   ._�5(      � 	 � ColumnDefinitions	 5)      �� 5*      $��3* �6+   �� 5+      $	��290 �6+   .+�5.      � $��0��6   $
��Left=�5/      $��Center=�50      .+�51      �� $��	30 0 20 0q�6%   $	��600��68   
 �� Orientation$
 
Horizontal=�6D   .+�52      �� 
������� �� CornerRadius$ 20��68   $	��350��6J   $��40��6V   $
��Left=�6b   $��Bottom=�6}   
���   �$��1q�6�   ._�53   "   �� $
 
Horizontal=�6-   .+�54   &   '  !MaterialDesignThemes.Wpf.PackIcon  $��	20 0 10 0q�6>   
���   � J� Opacity$	 0.4Q�6d      Kind$ 
FindInPage=�6r   $��20��6�   $��20��6�   $��Center=�6�   $��Center=�6�   �� 55   &   -   5        $��	searchBox��55   �   $
��Left=�6.   $��0 10 0 0q�6I   $��15(�6\   $��Medium"�6j   $	��Top=�6   $��41��6�   $	��300��6�   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Search drinks or food��6   ��6�   �� *	SearchBox+ �� UpdateSourceTrigger$ PropertyChanged=�.��67   56   *     57   .   $ TextChanged��6=   . 58   2      6H   �� *findProducts+59   /   .��5:   B   5;   '   5<   #   5=      �� 5>      -   5        $��	filterBox��5>   �   $��20 0 0 0q�6'    & "MaterialDesignFloatingHintComboBox#��[ 6:   $ Filter��6w   $��15(�6�   $��Medium"�6�   $	��100��6�    5?   "     5@   &   $ SelectionChanged��65   . 5A   *      6@   �� *filterProducts+5B   '   5D      5F      5G      � 5H      $��1��6   $��Center=�5I      $��Center=�5J      .+�5K      �� 
�������$	��290��69   $��90��6E   $��1 0 0 0q�6Q   ._�5L      �� $
 
Horizontal=�6)   $��Center=�5M   )   $��Center=�5N   )   .+�5O   "   �� $	��Top=�6)   $
��Left=�6A   
������ $��30��6u   $��30��6�   $ 10000��6�    J� Clip 5P   &   @� 5Q   *    @� Center$ 15,15&�6:    @� RadiusX$ 15Q�6I    @� RadiusY$ 15Q�6V   ._�5S   &   �� $��UniformToFill=�6N   ��6,   �� *User.ImageData+6N   5T   #   �� 5U   "   $��10 0 0 0q�6-   $
 Vertical=�5V   -   $��Center=�5W   -   $��Center=�5X   -   .+�5Y   &   �� -   5         ��Name$
 Name��5Y   T   $��15(�60   $��DemiBold"�6>   ��6b   �� *User.NameEm+�� 5Z   &   -   5        $
 Role��5Z   Q   $��12(�60   $��Light"�6>   ��6_   �� *User.NameRole+5[   #   5\      5]      5^      5_      5`      5a      � 5c   
   $��1��6   $��2��6   ���#f8f8f8 5d      �� 5e      $��50 �6    �� 5f      $	��13* �6    .+�5h      � $��0��6   	 5i      �� 5j      $��1* �6'   �� 5k      $	��200 �6'   .+�5m      �� $
 
Horizontal=�6   $��0��66   $��30 0 0 0q�5n      $��Center=�5o      $
��Left=�5p      5s      � 5t      $��1��6   .+�5u      �� $
 
Horizontal=�6!   .+�5v      ��   MaterialDesignRaisedButton#��[ 6   $��1��5w      $��70��5y      
���   �
�������
���   �$��Update��5}      $��	10 0 10 0q�5~      ��5x      �� *updateProducts+5      �� 5�      #��[ 6   $��1��5�      $��70��5�      
���   �
�������$	��Add��5�      
���   �$��	10 0 10 0q�5�      ��5�      �� *addFoodWindow+5�      5�      5�      5�      � 5�      $��1��6   $	��Top=�6    $��Stretch=�68   .+�5�      �� -   5        $��listBox��5�   Y   $��30 0 0 0q�6   $��Center=�6i   $��Center=�6�   ��6,   �� *
MenuList+ �� Mode$ TwoWay=� �� SelectedItem 5�      �� *SelectedProduct+��5�      �� 5�      .R�5�      A�  A� Columns$ 4��6*   5�      ��5�      �� 5�      .R�5�      #  MaterialDesignThemes.Wpf.Card  $	��250��63   $	��150��6?   .��5�   "   � 	 5�   &   �� 5�   *   $	��100 �6;   �� 5�   *   $��1* �6;   .+�5�   &   � $��0��6+   .+�5�   .   �� $��Stretch=�6Q   $��Stretch=�6o   ��64   �� *	ImageData+6o   �� 5�   *   $��30��6p   $��30��6{   $��10q�6�    * &MaterialDesignFloatingActionMiniButton#��[ 6�   $��Right=�6�   $��Bottom=�6�   ��62   �� *DataContext.getImage+$ listBox��.��5�   .     $	 Add=�6F   
�������$��24��6d   $��24��6p   5�   +   5�   '   � 5�   &   $��10q�6+   $��1��67    5�   *   �� 5�   .   $��30 �6<   �� 5�   .   $��1* �6<   �� 5�   .   $��30 �6<   �� 5�   .   $��30 �6<   .+�5�   *   � $��0��6/   .+�5�   .   �� $��20(�6Q   $��Black"�6_   ��66   �� *
NameFood+6_   5�   +   � 5�   *   $��1��6/   .+�5�   .   ��  �� TextWrapping$
 Wrap=�67   $��10(�6h   $��Medium"�6v   ��6K   �� *Description+6v   5�   +   � 5�   *   $��2��6/   $
��Left=�6<   $��Bottom=�6W   .+�5�   .   �� $	��0 0q�69   $
 
Horizontal=�6F   $��Center=�6_   $��Right=�6z   .+�5�   2   �� $��15(�6R   
��� ���$
��Bold"�6t   ��6:   �� *Price+6�   �� 5�   2   $��Center=�6<   $	��VND��6W   $��15(�6b   $��DemiBold"�6p   5�   /   5�   +   �� 5�   *   $
 
Horizontal=�65   $��3��6N   $
��Left=�6[   $��Bottom=�6v   .+�5�   .   �� $��comboBox��67   $��15(�6�   $��Medium"�6�   $��80��6  ��6H   ��  �� Path$  DataContext.ListTypeString� �� RelativeSource ��  �� AncestorType" �� �� SelectedIndex 6�   �� *IdType+$ TwoWay=�5�   /     5�   .   $ Delete=�6F   
�������$��Center=�5�   G   $��Center=�5�   G   $��20��5�   G   $��20��5�   G   $��20 0 0 0q�5�   G   $��0q�5�   G    5�   2     5�   6   $ MouseLeftButtonDown��6E   . 5�   :      6P   �� *DataContext.deleteProduct+$ listBox��5�   7   5�   /   5�   +   5�   '   5�   #   5�      5�      5�      5�      5�      5�      5�      