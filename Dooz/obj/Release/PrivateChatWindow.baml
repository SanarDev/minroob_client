   M S B A M L   `   `   `  ���� B  >Minroob, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Dooz.convertersDooz.converters  clr-namespace:DoozDooz      Dooz.PrivateChatWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     4
converterxclr-namespace:Dooz.converters     @d2http://schemas.microsoft.com/expression/blend/2008     $localclr-namespace:Dooz     b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006    � Title$  PrivateChatWindow��$	��400��$	��450�� � 	Resources $  Dooz.converters.ColorConverter   ColorConverter(  "Dooz.converters.TimestampConverter  TimestampConverter+  %Dooz.converters.MessageOwnerConverter  MessageOwnerConverter  	RactStyle �� 
TargetType �� Property �� Value�� %w   &	        &	      &	 
     &	            �� " ��.���  � ��$	 0.3����  � �� �#DEDEDE.��� .+�� $��
10,10,10,0q� � RowDefinitions �� $��30 ��� $��* ��� $��60 �.+��� -    ��Name$ ToolbarTitle��$��16(�$��Private Chat���� -    ��Name$ MessageList��$��1��$��Disabled=����� .R��  �� $
��Auto ��� $
��Auto ��� $
��Auto ��� .+��� ����  �� 	Converter# [  ���� *SenderPlayerId+# [ �� $��1��$��0,5,0,0q�
���   �$
��Wrap=����� *	Message+�� $��2��$��Right=����� *	Timestamp+# [ �� $��3��$	��0.8��$��0,10,0,0q�$��Stretch=����#ECECEC���� " ��.���  � ��$ Stretch=�� $��2��$��40��$��5q�$��Bottom=�	 � ColumnDefinitions	 �� $��1* ��� $��80 �.+��� -   
 ��Name$
 
MessageBox��$��0��)  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Write a message��   
IsFloating . �� -   $��1��$��
10,0,0,-10q�$
��Send�� �� 	IsDefault .   MaterialDesignFlatButton#���  