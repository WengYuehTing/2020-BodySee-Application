   M S B A M L   `   `   `  ����B  >BodySee, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:BodySee.WindowsBodySee.Windows  5   	   #    BodySee.Windows.GestureWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:BodySee.Windows     5   	     � AllowsTransparency  . 
������  � WindowStyle$
 None=�5
   	    � Topmost .  � WindowState$ 	Maximized=�5   	    � Title$ GestureWindow��5   	   $	��450��6   $	��800��6,   .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   6,   �� 5      $��* �6   6)   �� 5      $
��Auto �6   6,    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   6.   �� 5      $��* �6   6+   .+�5   
   � $��Stretch=�6    J� Opacity$
 0.81Q�6-   $��30��6<   ���#B4C5FF$��2��6]   .+�5      � $��Center=�6   $��2q�60   $��Center=�6;    5      �� 5      $
��Auto �6'   66   �� 5       $��* �6'   63   .+�5"      �� $��../Images/quanping.png��6   $��0��68   6J   �� 5#      $��全屏��6   $��18(�6&   
�������$��Center=�6H   $��10,0,0,0q�6e   $��1��6w   $��Center=�6�   6�   5$      5%      � 5&   
   $��30��6   $
��Left=�6   $
 0.81Q�65   ���#FFB4B4$��1��6Y   .+�5'      � $��Center=�6   $��2q�60   $��Center=�6;    5(      �� 5)      $
��Auto �6$   64   �� 5*      $��* �6$   61   .+�5,      �� $��../Images/shanchu.png��6   $��0��67   6F   �� 5-      $��删除��6   $��18(�6&   
�������$
��Wrap=�6G   $��Center=�6[   $��0,10,0,0q�6x   $��1��6�   $��Center=�6�   6�   5.      5/      �� 50   
   -   5        $��GestureButton��50   .   $��1��6   $��1��6    J� IsManipulationEnabled . $
 0.01Q�6`   6�  � 51   
   $��Bottom=�6   $
 0.81Q�6*   $��30��69   ���#D7D7D7$��2��6Z   $��0��6g   $��2��6w    52      �� 53      $��2* �6    �� 54      .+�56      � $��Center=�6   $��355,2q�60   $��Center=�6?   $��2��6Z    57      �� 58      $
��Auto �6'   66   �� 59      $��* �6'   63   .+�5;      �� $��../Images/zuixiaohua.png��6   $��0��6:   6L   �� 5<      $��	最小化��6   $��18(�6'   
�������$��Center=�6I   $��10,0,0,0q�6f   $��1��6x   $��Center=�6�   6�   5=      5>      5?      5@      