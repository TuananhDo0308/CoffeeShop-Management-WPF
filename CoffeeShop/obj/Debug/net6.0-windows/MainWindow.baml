   M S B A M L   `   `   `  ����  
CoffeeShop    CoffeeShop.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   -   5          � Title$  Login��5   	   $	��400��6   $	��700��6$    � AllowsTransparency$
 True��5	   	    � WindowStartupLocation$ CenterScreen=�5
   	    � WindowStyle$
 None=�5   	   
������  � 
ResizeMode$ NoResize=�5   	   $��16(�5   	      MaterialDesignFont#���   5   	   .��5      � $��20q�6    J� Effect 5   
   3  -System.Windows.Media.Effects.DropShadowEffect  5         
BlurRadius$ 30Q�6      ShadowDepth$ 1Q�5         Opacity$	 0.4Q�5      5      	 � ColumnDefinitions	 5   
   �� 5      $��1.25* �6   6/   �� 5      $��1* �6   6,   .+�5!   
   �� $��0��6   
 �� CornerRadius$
 	10 0 0 10��6!   ��5"      �� 5#       �� ImageSource$G A\\Mac\Home\Downloads\CoffeeShop\CoffeeShop\Resource\Img\login.jpg��6    j� Stretch$ UniformToFill=�6m   5$      5&      �� 5(   
   $��1��6   
�������$
 	0 10 10 0��64   6O   � 5)   
   $��1��6    � RowDefinitions 5*      �� 5+      $��20 �6    6.   �� 5,      $��1* �6    6.   .+�5.      �� $��0��6   $��1��6&    �� Orientation$ 
Horizontal=�66   $��Right=�6O   .+�5/      '  !MaterialDesignThemes.Wpf.PackIcon  -   5          Name$ btnMinimize��50   ,      Kind$ Minimize=�5/   *   $��Center=�51   ,   $��Center=�52   ,   $��0 13 5 0q�53   ,    J� Opacity$	 0.3Q�54   ,    � Cursor$
 Hand��55   ,   56   ,     58      -   5        $��btnClose��59   ,   $ Close=�58   *   $��Center=�5:   ,   $��Center=�5;   ,   $	 0.3Q�5<   ,   $��	0 13 14 0q�5=   ,   $
 Hand��5>   ,   5?   ,   5D      �� 5F      $��1��6   $��1��5G      $ Vertical=�5H      $��Center=�5I      $��Center=�5J      $	��200��5K      .+�5L      �� $��Sign in��6   $��Center=�5M      $��Center=�5N      $��20(�5O      $
��Bold"�5P      
��� ���$��0 0 0 10q�5R      �� 5S       % !MaterialDesignFloatingHintTextBox#��[ 6   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ 	User name��5T         FloatingOffset$ 0 -20&�5U      
�������$��	0 0 0 1.5q�5W      G� 5X       ) %MaterialDesignFloatingHintPasswordBox#��[ 6   $ Password��5Y      $ 0 -20&�5Z      
�������$��	0 0 0 1.5q�5\      $��0 10 0 0q�5]      �� 5^      $+��%Wrong username or password. Try again��6   $��9(�5_      $��
ExtraLight"�5`      
���  ��$��0 10 0 0q�5b      �� 5c      -   5         ��Name$ 	btnSignin��5c      $��Sign in��5d      $��Center=�5e      $��Center=�5f      $��0 20 0 0q�5g      
�������5i      5k      5l      5m      5n      