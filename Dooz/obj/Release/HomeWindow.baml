   M S B A M L   `   `   `  ���� B  >Minroob, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Dooz.convertersDooz.converters  1clr-namespace:Dooz.convertersDooz.converters  clr-namespace:DoozDooz  clr-namespace:DoozDooz      Dooz.HomeWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     4
converter1clr-namespace:Dooz.converters     4
converterxclr-namespace:Dooz.converters     @d2http://schemas.microsoft.com/expression/blend/2008     $localclr-namespace:Dooz     "srcclr-namespace:Dooz     b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006    � Title$  
HomeWindow��$
��1000��$	��450��   MaterialDesignBody#���    � 	Resources $  Dooz.converters.ColorConverter  ColorConverter(  "Dooz.converters.TimestampConverter  TimestampConverter  	RactStyle �� 
TargetType �� Property �� Value�� %h   &	       &	      &	 
         �� " ��.���  � ��$	 0.3����  � �� �#DEDEDE.��� .+��  � ColumnDefinitions �� $��1* ��� $��1* ��� $��1* ��� $
��1.5* �.+��� $��0��#��[ �� $��1��#��[ �� $��2��#��[ �� $��3��#��[ � $��0��$��10q� � RowDefinitions �� $
��Auto ��� $��* �.+��� $��16(�$��Your Account��� $��1��$��5q� �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto � �� $��* ��� $��* �.+��� $��0 10 0 0q�$��DemiBold"�$��	Username:��$��0���� -    ��Name$ TxtUsername��$��0 10 0 0q�$��	Username:��$��1���� $��0 10 0 0q�$��DemiBold"�$��
FullName: ��$��0��$��1���� -   $ TxtFullname��$��0 10 0 0q�$��1��$��1���� $��0 10 0 0q�$��DemiBold"�$��Total Games: ��$��0��$��2���� -   $ TxtNumberOfGamePlayed��$��0 10 0 0q�$��1��$��2���� $��0 10 0 0q�$��DemiBold"�$��Wins: ��$��0��$��3���� -   $ TxtWinsCount��$��0 10 0 0q�$��1��$��3���� -    ��Name$ 	BtnLogOut��$��Bottom=�$��1��$��Log out��� $��1��$��10q� �� $��30 ��� $��* ��� $��* �.+��� $��16(�$��Game Requests��� $��1�� �� $��30 ��� $��* �.+��� $��Incoming���� -   	 ��Name$	 InComingGameRequestsList��$��1������ .R��  �� �� �� $
��Auto �.+��  �� $��1* ��� $��1* �.+��� $	��5,8q�$��15(����� 
 �� 	Converter#
 [ ���� *
Fullname+� $��1��$��Right=� �� $��30 ��� $��30 �.+��� -   $��0��$��0q�  MaterialDesignToolButton#���   � ToolTip$ Denied Game Request����0  *MaterialDesignThemes.Wpf.PackIconExtension  *Cancel+
 � Tag �� *Id+�� $��BtnAcceptGame��-   $��1��$��0q�#���  $ Accept Game Request����  *CheckCircle+ �� *Id+�� $��2��$	��0.8��$��Stretch=����#ECECEC���� " ��.���  � ��$ Stretch=�� $��2�� �� $��30 ��� $��* �.+��� $��Outgoing���� -	   $	 OutGoingGameRequestsList��$��1������ .R��  �� �� �� $
��Auto �.+��  �� $��1* ��� $��1* �.+��� $	��5,8q�$��15(����� #
 [ ���� *
Fullname+� $��1��$��Right=� �� $��30 �.+��� $��BtnCancelRequest��-
   $��0��$��0q�#���  $ Cancel Game Request����  *Cancel+ �� *Id+�� $��2��$	��0.8��$��Stretch=����#ECECEC���� " ��.���  � ��$ Stretch=�� $��2��$��10q� �� $��30 ��� $��* �.+��� $��0��$��16(�$��Online Players���� -   $	 OnlinePlayerList��$��1��$��Disabled=����� .R��  �� �� �� $
��Auto �.+��  �� $��1* ��� $��1* �.+��� $	��5,8q�$��15(����� #
 [ ���� *
Fullname+� $��1��$��Right=� �� $��30 ��� $��30 �.+��� $��BtnSendMessage��-   $��0��$��0q�#���  $ Send Message����  *MessageText+ �� *Id+�� $��
BtnRequest��-   $��1��$��0q�#���  $ Send Game Request����  *GoogleController+ �� *Id+�� $��2��$	��0.8��$��Stretch=����#ECECEC���� " ��.���  � ��$ Stretch=�� $��3��$��10q� �� $��30 ��� $��* ��� $��50 �.+��� $��0��$��16(�$��Global Chat���� -   $	 GlobalChatList��$��1��$��Disabled=����� .R��  �� �� �� �� $
��Auto �.+��� $
��10,2q�$��12(�$
��Bold"����� #
 [ ���� *
Fullname+�� $��1��$
��10,1q�$��12(�$
��Wrap=����� *	Message+�� $��2��$
��10,1q�$��Right=�$��12(����� *	Timestamp+#
 [ �� $��3��$	��0.8��$��Stretch=����#ECECEC���� " ��.���  � ��$ Stretch=�� $��2��$��40��$��5q�$��Bottom=� �� $��1* ��� $��80 �.+��� -    ��Name$ 
MessageBox��$��0��)  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Write a message��   
IsFloating . �� -   $��1��$��
10,0,0,-10q�$
��Send�� �� 	IsDefault .   MaterialDesignFlatButton#���  )  #MaterialDesignThemes.Wpf.DialogHost     IsOpen �� *IsShowWaitingDialog+   DialogContent � $��40 15 40 15q�$	��200�� �� $��40 ��� $��* ��� $��40 �.+��� $ ��Waiting For Start Game ...��$��Center=�$��DemiBold"�� $��1��$��Center=�$��0 0 0 10q� �� $��1* ��� $��1* �.+��� -   $ TxtWaitingDialog��$��15(�$��Center=�$��DemiBold"��� -   $ BtnCancelWaitingDialog��$��2��$��Cancel��#���  $��Bottom=�   �� *IsShowResumeGameDialog+ � $��30 15 30 15q�$	��200�� �� $��40 ��� $��* ��� $��35 ��� $��35 �.+��� $��Resume Game��$��Center=�$��16(�$��DemiBold"�� $��1��$��Center=�$��0 0 0 10q� �� $��1* ��� $��1* �.+��� -   $ TxtResumeGameDialog��$D��>You have a game with Mibina Doroki . Do you want to resume it?��$
��Wrap=�$	��250��$��14(�$��Center=�$��DemiBold"��� -   $ BtnCancelResumeGame��$��2��$��Cancel��#���  $��Bottom=��� -   $ BtnAcceptResumeGame��$��3��$��Resume��  MaterialDesignRaisedButton#���  $��Bottom=�'  !MaterialDesignThemes.Wpf.Snackbar  $��2��$��0q�$��0q�$��Bottom=�   IsActive �� *IsActiveSnackBar+   Message. .  (MaterialDesignThemes.Wpf.SnackbarMessage  ���� *SnackbarMessage+