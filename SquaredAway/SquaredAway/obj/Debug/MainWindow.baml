   M S B A M L   `   `   `  ����F  BSquaredAway, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:SquaredAwaySquaredAway  5   	       SquaredAway.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:SquaredAway     5   	     � Title$  Squared Away��5   	   $	��600��6   $	��850��6+    � 
ResizeMode$ NoResize=�5	   	   .��5
      �  � ColumnDefinitions 5   
   �� 5      �� 5      $
��Auto �6   $	��600��6,    � RowDefinitions 5   
   �� 5      $
��190* �6   �� 5      $
��381* �6   .+�5   
   ��  �� Orientation$ Vertical=�6   .+�5      �� -   5        $��label_LevelName��5      $��28(�6+   .��69   
Level Name5      �� 5      -   5        $��label_PlayerShifts��5      $��24(�6.   .��6<   	Shifts: 05      �� 5      .+�5      �� -   5        $��44��5   /   .��5      �� $��20(�6   .��6*   	Restart63   5      5      5       �� 5!   
   $��0��6   $��1��6(   .��5"      �� -   5        $��stackPanel_Levels��5"      $ Vertical=�62   5$      5%      �� 5&   
   -   5        $��canvas_Board��5&      $	��500��6%   $	��500��61   $��Center=�6>   $��Center=�6[   $��1��6v   $��0��6�   $��2��6�   ��5'      �� 5(       �� Color$ 	AliceBlue��6"   66   5+      5-      5.      