   M S B A M L   `   `   `  ����E  APassportPO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullW0clr-namespace:PassportPO.ViewModel.PageViewModel"PassportPO.ViewModel.PageViewModel  5           PassportPO.View.PassportUC   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ?vm0clr-namespace:PassportPO.ViewModel.PageViewModel     5      $	��500��5      $	��800��6     � DataContext  5	      3  -PassportPO.ViewModel.PageViewModel.PassportVm  5
   
   .��5      ]� .+�5   
   �� $��Bottom=�6    �� Orientation$ 
Horizontal=�6-   $��Right=�6F   $��
0,10,10,10q�6b   .+�5      �� $��
Назад��6   $��20(�6%   ��63   �� *
BackButton+�� 5      $��10��6   �� 5      $%��Обновить таблицу��6   $��20(�60   ��6>   �� *RefrashButton+�� 5      $��10��6   �� 5      $4��.Добавить/Изменить запись��6   $��20(�68   ��6F   �� *	AddButton+5      �� 5   
   $ 
Horizontal=�6   $��Bottom=�6.   $
��Left=�6F   .+�5      �� $G��AЯ желаю изменить или удалить запись��66   $��20(�6d    d� 	IsChecked 6   �� *
CheckBox+y�6r   �� *	Visible+    BooleanToVisibilityConverter �� 	Converter# [  5      �� 5   
   $��3��6   
�������$��Bottom=�6.   ]� 5      $��Bottom=�6   y�6-   �� *	Visible+# [  .+�5   
   �� $ Vertical=�6   $
��Left=�6,   $��40,0,0,0q�6B   y�6T   �� *
CheckBox+# [  .+�5      �� $��Выберите ID��6   $��20(�6+   �� 5      ��6   �� *	Idsstring+ �� UpdateSourceTrigger$ PropertyChanged=� �� SelectedItem 6^   �� *IdStrstring+5       �� 5!   
   $
��Left=�6   $��
Поиск��6(   $��40,0,0,0q�68   y�6J   �� *
CheckBox+# [  ��6�   �� *Search+�� 5"   
   $ Vertical=�6   $
��Left=�6,   $��40,0,0,0q�6B   .+�5#      �� $��Имя��6   $��20(�6#   �� 5$      ��6   �� *
Namestring+$ PropertyChanged=�5%      �� 5&   
   $ Vertical=�6   $
��Left=�6,   $��40,0,0,0q�6B   .+�5'      �� $��Фамилия��6   $��20(�6'   �� 5(      ��6   �� *SurNamestring+$ PropertyChanged=�5)      �� 5*   
   $ Vertical=�6   $
��Left=�6,   $��40,0,0,0q�6B   .+�5+      �� $��Отчество��6   $��20(�6(   �� 5,      ��6   �� *SecondNamestring+$ PropertyChanged=�5-      �� 5.   
   $ Vertical=�6   $
��Left=�6,   $��40,0,0,0q�6B   .+�5/      �� $��Гражданство��6   $��20(�6+   �� 50      ��6   �� *SitizenShipstring+$ PropertyChanged=�51      �� 52   
   $ Vertical=�6   $
��Left=�6,   $��40,0,0,0q�6B   .+�53      �� $'��!Код Подразделения��6   $��20(�61   �� 54      ��6   �� *	Kodstring+$ PropertyChanged=�55      �� 56   
   $ Vertical=�6   $
��Left=�6,   $��40,0,0,0q�6B   .+�57      �� $��Кем Выдан��6   $��20(�6)   �� 58      ��6   �� *	Kemstring+$ PropertyChanged=�59      �� 5<      $ Vertical=�6   $��Right=�60   $��	50,0,10,0q�6G   .+�5=      �� $��Добавить��6   $	��100��6,   $��20(�6;   ��6I   �� *AddInBdButton+�� 5>      
�������$��3��60   �� 5?      $��Изменить��6   $	��100��6,   $��20(�6;   ��6I   �� *ChangeButton+�� 5@      
�������$��3��60   �� 5A      $��Удалить��6   $	��100��6+   $��20(�6:   ��6H   �� *DeleteButton+5B      5C      &   System.Windows.Controls.DataGrid  5F   
      AutoGenerateColumns$ False��5G      $��20(�5H      ��5F      �� *PassportLists+$ PropertyChanged=�   Columns 5J      0  *System.Windows.Controls.DataGridTextColumn  5K      ,  &System.Windows.Controls.DataGridColumn   Header$ Id��6%   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 61   �� *Id+  5L      $ Имя��6%   	 62   �� *Name+  5M      $ Фамилия��6%   	 66   �� *	Surname+  5N      $ Отчество��6%   	 67   �� *
SecondName+  5O      $ Гражданство��6%   	 6:   �� *Citizenship+  5P      $' !Код Подразделения��6%   	 6@   �� *Kod+  5Q      $ Кем Выдан��6%   	 68   �� *Kem+5S      5T      5U      