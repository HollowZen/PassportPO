   M S B A M L   `   `   `  ����E  APassportPO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullW0clr-namespace:PassportPO.ViewModel.PageViewModel"PassportPO.ViewModel.PageViewModel  5          PassportPO.View.ViseUC   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ?vm0clr-namespace:PassportPO.ViewModel.PageViewModel     5      $	��500��5      $	��800��6     � DataContext  5	      /  )PassportPO.ViewModel.PageViewModel.ViseVm  5
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
�������$��Bottom=�6.   ]� 5   
   $��Bottom=�6   y�6,   �� *	Visible+# [  .+�5      �� $ Vertical=�6   $
��Left=�60   $��40,0,0,0q�6F   y�6X   �� *
CheckBox+# [  .+�5      �� $��Выберите ID��6   $��20(�6/   �� 5      ��6   �� *	Idsstring+ �� SelectedItem 6=   �� *IdStrstring+5       �� 5!      $
��Left=�6   $��
Поиск��6,   $��40,0,0,0q�6<   y�6N   �� *
CheckBox+# [  ��6�   �� *Search+�� 5"      $ Vertical=�6   $
��Left=�60   $��40,0,0,0q�6F   .+�5#      �� $��Имя��6   $��20(�6'   �� 5$      ��6   �� *
Namestring+5%      �� 5&      $ Vertical=�6   $
��Left=�60   $��40,0,0,0q�6F   .+�5'      �� $��Фамилия��6   $��20(�6+   �� 5(      ��6   �� *SurNamestring+5)      �� 5*      $ Vertical=�6   $
��Left=�60   $��40,0,0,0q�6F   .+�5+      �� $��Отчество��6   $��20(�6,   �� 5,      ��6   �� *SecondNamestring+5-      �� 5.      $ Vertical=�6   $
��Left=�60   $��40,0,0,0q�6F   .+�5/      �� $��Гражданство��6   $��20(�6/   �� 50      ��6   �� *SitizenShipstring+51      �� 52      $ Vertical=�6   $
��Left=�60   $��40,0,0,0q�6F   .+�53      �� $��Статус��6   $��20(�6*   �� 54      ��6   �� *Statusstring+55      �� 58      $ Vertical=�6   $��Right=�60   $��	50,0,10,0q�6G   .+�59      �� $��Добавить��6   $	��100��6,   $��20(�6;   ��6I   �� *AddInBdButton+�� 5:      
�������$��3��60   �� 5;      $��Изменить��6   $	��100��6,   $��20(�6;   ��6I   �� *ChangeButton+�� 5<      
�������$��3��60   �� 5=      $��Удалить��6   $	��100��6+   $��20(�6:   ��6H   �� *DeleteButton+5>      5?      � 5B   
   -   5         �Name$
 Grid��5B      .+�5C      &   System.Windows.Controls.DataGrid     
IsReadOnly$
 True��6      AutoGenerateColumns$ False��6*   $��20(�6i      GridLinesVisibility$ Vertical=�6w   ��6F   �� *	VizeLists+	   Columns	 5D      0  *System.Windows.Controls.DataGridTextColumn  5E      ,  &System.Windows.Controls.DataGridColumn
   Header$
 ID��6)   1  +System.Windows.Controls.DataGridBoundColumn   Binding 65   �� *Id+  5F      $
 Имя��6)    66   �� *Name+  5G      $
 Фамилия��6)    6:   �� *	SurName+  5H      $
 Отчество��6)    6;   �� *
SecondName+  5I      $
 Гражданство��6)    6>   �� *CitizenShip+4  .System.Windows.Controls.DataGridCheckBoxColumn  5J      $
 Статус��6-    6=   �� *Status+5L      5M      5N      5O      