   M S B A M L   `   `   `  ���� V  RStudentsProgramOrganisation, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:StudentsProgramOrganisationStudentsProgramOrganisation  ,    &StudentsProgramOrganisation.MainWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     ;local)clr-namespace:StudentsProgramOrganisation     V RMaterialDesignThemes.Wpf, Version=2.5.1.1345, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes     MaterialDesignBody#���   $��Regular"�$��13(�&   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�   TextRenderingMode$
 Auto=�  MaterialDesignPaper#���    MaterialDesignFont#���   � Title$ Organizator��$	��800��$
��1440�� � WindowStartupLocation$ CenterScreen=� � WindowStyle$
 None=� � 
ResizeMode$ NoResize=�.��� $��10 10q�.+���  �� Orientation$ 
Horizontal=�.+��� .+���    MaterialDesignTitleTextBlock#���  $��10q�
Ustawienia��  & "MaterialDesignFloatingActionButton#���  $
��0 15q�$��5q�.��	Dni nauki�� -   $��Exit_Button��  MaterialDesignFlatButton#���  .��Wyjdź�� .+��� $	��5 5q�$
��Bold"�$��18(�Podział godzin:� $	��305��.+�&   System.Windows.Controls.DataGrid  -   $��TimeTable_DataGrid��  MaterialDesignDataGrid#���  $	��699��$��
0,0,0.2,10q�9� $��Zarządzanie zajęciami��.��� .+��� .+��� $ 
Horizontal=�.+��� -   $��AddSubject_Button�� $  MaterialDesignRaisedAccentButton#���  $	��5 5q�.��Dodaj&   System.Windows.Controls.Calendar  -   $��AddSubject_Callendar��$��5q��� .+��� $	��5 5q�$
��Bold"�.��Nazwa:�� -   $��AddSubjectName_TextBox��$	��290��$	��5 5q��� $	��5 5q�$
��Bold"�.��
Godzina:)  #MaterialDesignThemes.Wpf.TimePicker  -   $��AddSubject_TimePicker��$	��5 5q��� $��Center=�$
��Bold"�$
��0 20q�Usuń zajęcia:�� $
��0 10q�.+��� $	��5 5q�$
��Bold"�$��Center=�.��Usuń wybrany element.�� -   $��DeleteSubject_Button�� # MaterialDesignRaisedLightButton#���  $	��5 5q�.��Usuń9� $��Nauka do egzaminu�� 9� ExpandDirection$ Up=�$��RightToLeft=�.���� .+�� .+�  -   $��WhatToLearnToday_DataGrid��$	��362���� .+�� .+�(  "System.Windows.Controls.WebBrowser  -	   $��WB��$	��400��$	��600��   Source$) #https://jakdojade.pl/rzeszow/trasa/?�� .+�9� $��Egzaminy��$��16(�.��� $	��612��$	��338��.+��� $ 
Horizontal=�.+�� .+�  -
   $��ExamGrid��#���  $	��300��$	��310���� $ 
Horizontal=�$	��342��.+��� $	��281��$��Center=�$��5q�.+��� -   $��ExamName_TextBox��$	��333��$��5q�.��nazwa egzaminu..�� $ 
Horizontal=�$��5q�.+��� .��Wybierz date'  !MaterialDesignThemes.Wpf.PopupBox  $
��10 0q�	   PopupContent.	   -   $��ExamDate_Calendar���� -   $��AddExam_Button��$	��5 5q�#���  .��Dodaj egzamin�� -   $��DeleteExam_Button��$	��5 5q�.��Usuń egzamin