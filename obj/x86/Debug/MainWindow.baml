   M S B A M L   `   `   `  ����M  ITestRegressionTool, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:TestRegressionToolTestRegressionTool  5   	   #    TestRegressionTool.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:TestRegressionTool     5   	   Ddxc4http://schemas.devexpress.com/winfx/2008/xaml/charts     5   	   -   5          �Name$  TestRegressionTool��5   	    � Title$ Test Regression Tool��5	   	   $��715.75��6&   $
��1109��66    � 
ResizeMode$ CanMinimize=�6C    � WindowStartupLocation$ CenterScreen=�6\   .��5      �  � ColumnDefinitions 5   
   �� 5      $	��23* �6   �� 5      $
��150* �6   .+�5   
   �� $.��(Enter Raw Max Mark (Component Max Mark):��6   $
��Left=�6C   $��	22,10,0,0q�6^   $	��Top=�6q   $��2��6�   �� 5   
   -   5         ��Name$ 
maxMarksTB��5      $
��Left=�6&   $��23��6A   $��
143,10,0,0q�6M    �� TextWrapping$
 Wrap=�6a   $�� ��6u   $	��Top=�6}   $	��120��6�   $��1��6�   �� 5   
   $!��Enter Regression Tolerance:��6   $
��Left=�66   $��
357,10,0,0q�6Q   $	��Top=�6e   $��1��6}   �� 5   
   -   5        $ toleranceTB��5      $
��Left=�6'   $��23��6B   $��
548,10,0,0q�6N   $
 Wrap=�6b   $�� ��6v   $	��Top=�6~   $	��120��6�   $��1��6�   9� 5   
   $ ��Custom Regression Scenario��6   $
��Left=�67   $	��100��6R   $��	22,90,0,0q�6_   $	��Top=�6r   $	��407��6�   $��2��6�    9� 
IsExpanded . .��5      �  5      �� 5      $	��11* �6'   �� 5      $
��394* �6'   .+�5      �� $&�� Count of Marks to be considered:��6   $��	0,0,-36,0q�6C   $��2��6V   �� 5      -   5        $ countTB��5      $
��Left=�6+   $��23��6F   $��
274,0,0,54q�6R   $
 Wrap=�6f   $�� ��6z   $	��120��6�   $��1��6�   �� 5      $$��Percentage of Moderator Marks:��6   $��
0,23,0,-23q�6A   $��2��6U   �� 5      -   5        $ percentageModeratorTB��5      $
��Left=�69   $��23��6T   $��
274,28,0,0q�6`   $
 Wrap=�6t   $�� ��6�   $	��Top=�6�   $	��120��6�   $��1��6�   �� 5       -   5        $��	cr_button��5       $��Initiate Regression��6*   $��
0,50,294,0q�6H   $��2��6t   5!      5"      9� 5#   
   $��Upload Regression File��6   $
��Left=�63   $��57��6N   $��
357,90,0,0q�6Z   $	��Top=�6n   $	��407��6�   $��1��6�    . .��5$      �� -   5        $$��Upload and Initiate Regression��5$      $��Right=�6>   $	��180��6Z   $��24��6f   $��	0,0,225,0q�6�   5%      &   System.Windows.Controls.DataGrid  5&   
   -   5          Name$ finalResultsDG��5&      $��22,222,288,62q�6I   $��2��6`   	   AutoGenerateColumns	 . ��6+   �� *Marks+6t   �� 5(   
   -	   5        
 ��Name$
 timelb��5(      $ ��Total Time Taken: 00:00:00��6    $��1��6E   $
��Left=�6U   $��
638,50,0,0q�6p   $	��Top=�6�   5+      5,      