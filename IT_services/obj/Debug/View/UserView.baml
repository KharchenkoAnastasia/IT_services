   M S B A M L   `   `   `  ����F  BIT_services, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:IT_services.ViewIT_services.View  5   	   =#clr-namespace:IT_services.ViewModelIT_services.ViewModel  5   	       IT_services.View.UserView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:IT_services.View     5   	   9	viewmodel#clr-namespace:IT_services.ViewModel     5   	     � Title$  Головне вікно��5	   	   $��711.57��6   $��1277.989��6/    � WindowStartupLocation$ CenterScreen=�5
   	   .��5      � -   5        $��grMain1��5      $��0,0,3.2,25.6q�6    � DataContext 5   
   )  #IT_services.ViewModel.UserViewModel  5      5      .+�5   
   &   System.Windows.Controls.DataGrid  -   5        $	��dg1��5      $��1��6       AutoGenerateColumns .     CanUserDeleteRows .     CanUserAddRows .  $
��Left=�6�   $	��356��6�   $��
40,150,0,0q�6�   $	��Top=�6�   $
��1178��6�   $��Arial)�6  $��16(�6  ��64   �� *ser+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ 
Номер��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 10 64   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 6?   �� *id+  5      $ Назва послуги��6%   $	 200 6<   	 6H   �� *name+  5      $ Від��6%   $	 150 62   	 6>   �� *start+  5      $
 До��6%   $	 150 61   	 6=   �� *konets+  5      $ 
Місто��6%   $	 150 64   	 6@   �� *city+  5      $ Ціна��6%   $	 150 63   	 6?   �� *price+  5      $ Телефон��6%   $	 150 66   	 6B   �� *phone+  5      $ Опис��6%   $	 200 63   	 6?   �� *
decription+5      �� 5   
   $��Мої послуги��6   $
��Left=�6&   $��
505,74,0,0q�6A   $	��Top=�6U   $��Arial)�6m   $��36(�6�   $	��218��6�   �� 5   
   $��Видалити��6   $
��Left=�6�   $��305,555,0,0q�6�   $	��Top=�6�   $	��222��6�   $��Arial)�6�   $��16(�6  $��51��6  ��6$   �� *Delete+��6?   �� 
 �� RelativeSource
 �� *FindAncestor+ �� AncestorType" �6  �� 5   
   $��Додати��6   $
��Left=�6�   $��
40,555,0,0q�6�   $	��Top=�6�   $	��222��6�   $��Arial)�6�   $��16(�6  $��51��6  ��6"   �� *Add+��6:   �� 
 �� *FindAncestor+" �6  �� 5   
   $+��%Перегляд замовників��6   $
��Left=�6�   $��561,555,0,0q�6�   $	��Top=�6�   $	��222��6�   $��Arial)�6  $��16(�6  $��51��6%  ��6/   �� *Read+��6H   �� 
 �� *FindAncestor+" �6%  �� 5    
   $
��Left=�6*   $��27��6E   $��
146,39,0,0q�6Q   $
��Wrap=�6e   $	��Top=�6z   $	��120��6�   $��Arial)�6�   $��16(�6�   ��6   �� *name+6�   �� 5!   
   $��Користувач:��6   $
��Left=�6&   $��50��6A   $��	44,34,0,0q�6M   $	��Top=�6`   $	��107��6x   $��Arial)�6�   $��16(�6�   5"      5#      