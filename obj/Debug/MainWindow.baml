   M S B A M L   `   `   `  ����M  ITestRegressionTool, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:TestRegressionToolTestRegressionTool  5   	   #    TestRegressionTool.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:TestRegressionTool     5   	   Ddxc4http://schemas.devexpress.com/winfx/2008/xaml/charts     5   	   -   5          �Name$  TestRegressionTool��5   	    � Title$ Test Regression Tool��5	   	   $��715.75��6&   $
��1109��66    � 
ResizeMode$ CanMinimize=�6C    � WindowStartupLocation$ CenterScreen=�6\   .��5
      �  � ColumnDefinitions 5   
   �� 5      $	��23* �6   �� 5      $
��150* �6   .+�5   
   �� $.��(Enter Raw Max Mark (Component Max Mark):��6   $
��Left=�6C   $��	22,10,0,0q�6^   $	��Top=�6q   $��2��6�   �� 5   
   $
��Left=�6   $��23��6-   $��
143,10,0,0q�69    �� TextWrapping$
 Wrap=�6M   $�� ��6a   $	��Top=�6i   $	��120��6�   $��1��6�   �� 5   
   $!��Enter Regression Tolerance:��6   $
��Left=�66   $��
357,10,0,0q�6Q   $	��Top=�6e   $��1��6}   �� 5   
   $
��Left=�6   $��23��6-   $��
548,10,0,0q�69   $
 Wrap=�6M   $�� ��6a   $	��Top=�6i   $	��120��6�   $��1��6�   9� 5   
   $ ��Custom Regression Scenario��6   $
��Left=�67   $	��100��6R   $��	22,90,0,0q�6_   $	��Top=�6r   $	��407��6�   $��2��6�   .��5      �  5      �� 5      $	��11* �6'   �� 5      $
��394* �6'   .+�5      �� $&�� Count of Marks to be considered:��6   $��	0,0,-36,0q�6C   $��2��6V   �� 5      $
��Left=�6   $��23��65   $��
274,0,0,54q�6A   $
 Wrap=�6U   $�� ��6i   $	��120��6q   $��1��6}   �� 5      $$��Percentage of Moderator Marks:��6   $��
0,23,0,-23q�6A   $��2��6U   �� 5      $
��Left=�6   $��23��65   $��
274,28,0,0q�6A   $
 Wrap=�6U   $�� ��6i   $	��Top=�6q   $	��120��6�   $��1��6�   �� 5      -   5        $��	cr_button��5      $��Initiate Regression��6*   $��
0,50,294,0q�6H   $��2��6t   5      5      9� 5    
   $��Upload Regression File��6   $
��Left=�63   $��57��6N   $��
357,90,0,0q�6Z   $	��Top=�6n   $	��407��6�   $��1��6�   .��5!      �� $$��Upload and Initiate Regression��6   $
��Left=�6>   $	��180��6Y   $��24��6e   5"      &   System.Windows.Controls.DataGrid  5#   
   $
��Left=�6   $	��394��6.   $��
22,217,0,0q�6;   $	��Top=�6O   $	��793��6g   $��2��6s   �� 5$   
   $ ��Total Time Taken: 00:00:00��6   $��1��65   $
��Left=�6E   $��
638,50,0,0q�6`   $	��Top=�6t   5'      5(      