; �ýű�ʹ�� HM VNISEdit �ű��༭���򵼲���

; ��װ�����ʼ���峣��
!define PRODUCT_NAME "��ӯӯ��Ʊ����ϵͳ"
!define VERSION_NAME "������"
!define PRODUCT_VERSION "3.1.44"
!define PRODUCT_PUBLISHER "��ӯӯ����Ƽ����޹�˾"
!define PRODUCT_DIR_REGKEY "Software\Microsoft\Windows\CurrentVersion\App Paths\��ӯӯ.exe"
!define PRODUCT_WEB_SITE "http://www.caiyingying.com"
!define PRODUCT_UNINST_KEY "Software\Microsoft\Windows\CurrentVersion\Uninstall\${PRODUCT_NAME}"
!define PRODUCT_UNINST_ROOT_KEY "HKLM"

SetCompressor lzma

; ------ MUI �ִ����涨�� (1.67 �汾���ϼ���) ------
!include "MUI.nsh"

; MUI Ԥ���峣��
!define MUI_ABORTWARNING
; MUI Settings / Icons
; ��װ��ͼ��
!define MUI_ICON "CYY\config\img\install.ico"
;!define MUI_UNICON "${NSISDIR}\Contrib\Graphics\Icons\modern-uninstall.ico"
;!define MUI_ICON "${NSISDIR}\Contrib\Graphics\Icons\orange-install.ico"
!define MUI_UNICON "${NSISDIR}\Contrib\Graphics\Icons\orange-uninstall.ico"

; MUI Settings / Header
!define MUI_HEADERIMAGE
!define MUI_HEADERIMAGE_RIGHT
!define MUI_HEADERIMAGE_BITMAP "${NSISDIR}\Contrib\Graphics\Header\orange-r.bmp"
!define MUI_HEADERIMAGE_UNBITMAP "${NSISDIR}\Contrib\Graphics\Header\orange-uninstall-r.bmp"

; MUI Settings / Wizard
!define MUI_WELCOMEFINISHPAGE_BITMAP "${NSISDIR}\Contrib\Graphics\Wizard\orange.bmp"
!define MUI_UNWELCOMEFINISHPAGE_BITMAP "${NSISDIR}\Contrib\Graphics\Wizard\orange-uninstall.bmp"

; ��ӭҳ��
!insertmacro MUI_PAGE_WELCOME
; ���Э��ҳ��
!insertmacro MUI_PAGE_LICENSE "CYY\config\lic.txt"
; ��װĿ¼ѡ��ҳ��
;!insertmacro MUI_PAGE_DIRECTORY
; ��װ����ҳ��
!insertmacro MUI_PAGE_INSTFILES
; ��װ���ҳ��
!define MUI_FINISHPAGE_RUN "��ӯӯ.exe"
!insertmacro MUI_PAGE_FINISH

; ��װж�ع���ҳ��
!insertmacro MUI_UNPAGE_INSTFILES

; ��װ�����������������
!insertmacro MUI_LANGUAGE "SimpChinese"

; ��װԤ�ͷ��ļ�
!insertmacro MUI_RESERVEFILE_INSTALLOPTIONS
; ------ MUI �ִ����涨����� ------

Name "${PRODUCT_NAME}-${VERSION_NAME}v${PRODUCT_VERSION}"
OutFile "${PRODUCT_NAME}${VERSION_NAME}v${PRODUCT_VERSION}.exe"
InstallDir "C:\CYY"
ShowInstDetails show
ShowUnInstDetails show

Section "MainSection" SEC01
  SetOutPath "C:\CYY"
  ;SetOverwrite ifnewer
  ;SetOverwrite off
  SetOverwrite on ;���ǰ�װ
  File /r "CYY\*.*"
SectionEnd

Section -AdditionalIcons
  SetOutPath $INSTDIR
  CreateDirectory "$SMPROGRAMS\��ӯӯ����Ƽ����޹�˾"
  CreateShortCut "$SMPROGRAMS\��ӯӯ����Ƽ����޹�˾\Uninstall.lnk" "$INSTDIR\uninstall.exe"
  CreateShortCut "$SMPROGRAMS\��ӯӯ����Ƽ����޹�˾\��ӯӯ.lnk" "$INSTDIR\��ӯӯ.exe"
  CreateShortCut "$SMPROGRAMS\��ӯӯ.lnk" "$INSTDIR\��ӯӯ.exe"
  CreateShortCut "$DESKTOP\��ӯӯ.lnk" "$INSTDIR\��ӯӯ.exe"
SectionEnd

Section -Post
  WriteUninstaller "$INSTDIR\uninstall.exe"
  WriteRegStr ${PRODUCT_UNINST_ROOT_KEY} "${PRODUCT_UNINST_KEY}" "DisplayName" "$(^Name)"
  WriteRegStr ${PRODUCT_UNINST_ROOT_KEY} "${PRODUCT_UNINST_KEY}" "UninstallString" "$INSTDIR\uninstall.exe"
  WriteRegStr ${PRODUCT_UNINST_ROOT_KEY} "${PRODUCT_UNINST_KEY}" "DisplayVersion" "${PRODUCT_VERSION}"
  WriteRegStr ${PRODUCT_UNINST_ROOT_KEY} "${PRODUCT_UNINST_KEY}" "DisplayIcon" "$INSTDIR\config\img\icon.ico"
  WriteRegStr ${PRODUCT_UNINST_ROOT_KEY} "${PRODUCT_UNINST_KEY}" "Publisher" "��ӯӯ����Ƽ����޹�˾"
  
  WriteRegStr HKCU "${PRODUCT_UNINST_KEY}" "DisplayName" "${PRODUCT_NAME}"
  WriteRegStr HKCU "${PRODUCT_UNINST_KEY}" "VersionName" "${VERSION_NAME}"
  WriteRegStr HKCU "${PRODUCT_UNINST_KEY}" "DisplayVersion" "${PRODUCT_VERSION}"
  
	;http://blog.sina.com.cn/s/blog_407c173601007v2n.html
	;WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\$(^Name)" "InstallLocation" "$INSTDIR"
  ;WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\$(^Name)" "DisplayIcon" "CYY\config\img\icon.ico"
  ;WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\$(^Name)" "Publisher" "��ӯӯ����Ƽ����޹�˾"
SectionEnd

/******************************
 *  �����ǰ�װ�����ж�ز���  *
 ******************************/

Section Uninstall
  Delete "$INSTDIR\uninstall.exe"

  Delete "$SMPROGRAMS\��ӯӯ����Ƽ����޹�˾\Uninstall.lnk"
  
	Delete "$DESKTOP\��ӯӯ.lnk"
	
	Delete "$SMPROGRAMS\��ӯӯ.lnk"
	
  RMDir "$SMPROGRAMS\��ӯӯ����Ƽ����޹�˾"

  RMDir /r "C:\CYY"

  RMDir "$INSTDIR"

  DeleteRegKey ${PRODUCT_UNINST_ROOT_KEY} "${PRODUCT_UNINST_KEY}"
  SetAutoClose true
SectionEnd

#-- ���� NSIS �ű��༭�������� Function ���α�������� Section ����֮���д���Ա��ⰲװ�������δ��Ԥ֪�����⡣--#

Function un.onInit
  MessageBox MB_ICONQUESTION|MB_YESNO|MB_DEFBUTTON2 "��ȷʵҪ��ȫ�Ƴ� $(^Name) ���������е������" IDYES +2
  Abort
FunctionEnd

Function un.onUninstSuccess
  HideWindow
  MessageBox MB_ICONINFORMATION|MB_OK "$(^Name) �ѳɹ��ش����ļ�����Ƴ���"
FunctionEnd

Var UNINSTALL_PROG
Var OLD_VER
Var OLD_PATH


Function un.onInit.backup
  ClearErrors
  ReadRegStr $UNINSTALL_PROG ${PRODUCT_UNINST_ROOT_KEY} ${PRODUCT_UNINST_KEY} "Software\Microsoft\Windows\CurrentVersion\Uninstall\${PRODUCT_NAME}"
  IfErrors  done

  ReadRegStr $OLD_VER ${PRODUCT_UNINST_ROOT_KEY} ${PRODUCT_UNINST_KEY} "Software\Microsoft\Windows\CurrentVersion\Uninstall\${PRODUCT_NAME}"
  MessageBox MB_YESNOCANCEL|MB_ICONQUESTION \
    "��⵽�����Ѿ���װ $(^Name) ${PRODUCT_VERSION}?\
    $\n$\n�Ƿ���ж���Ѱ�װ�İ汾?" \
      /SD IDYES \
      IDYES uninstall \
      IDNO done
  Abort

uninstall:
  StrCpy $OLD_PATH $UNINSTALL_PROG -10
  ExecWait '"$UNINSTALL_PROG" /S _?=$OLD_PATH' $0
  DetailPrint "uninstall.exe returned $0"
  Delete "$UNINSTALL_PROG"
  RMDir $OLD_PATH

done:
FunctionEnd
