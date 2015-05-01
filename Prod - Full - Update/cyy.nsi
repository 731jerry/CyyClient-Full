; 该脚本使用 HM VNISEdit 脚本编辑器向导产生

; 安装程序初始定义常量
!define PRODUCT_NAME "彩盈盈彩票做号系统"
!define VERSION_NAME "精华版"
!define PRODUCT_VERSION "3.1.44"
!define PRODUCT_PUBLISHER "彩盈盈网络科技有限公司"
!define PRODUCT_DIR_REGKEY "Software\Microsoft\Windows\CurrentVersion\App Paths\彩盈盈.exe"
!define PRODUCT_WEB_SITE "http://www.caiyingying.com"
!define PRODUCT_UNINST_KEY "Software\Microsoft\Windows\CurrentVersion\Uninstall\${PRODUCT_NAME}"
!define PRODUCT_UNINST_ROOT_KEY "HKLM"

SetCompressor lzma

; ------ MUI 现代界面定义 (1.67 版本以上兼容) ------
!include "MUI.nsh"

; MUI 预定义常量
!define MUI_ABORTWARNING
; MUI Settings / Icons
; 安装包图标
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

; 欢迎页面
!insertmacro MUI_PAGE_WELCOME
; 许可协议页面
!insertmacro MUI_PAGE_LICENSE "CYY\config\lic.txt"
; 安装目录选择页面
;!insertmacro MUI_PAGE_DIRECTORY
; 安装过程页面
!insertmacro MUI_PAGE_INSTFILES
; 安装完成页面
!define MUI_FINISHPAGE_RUN "彩盈盈.exe"
!insertmacro MUI_PAGE_FINISH

; 安装卸载过程页面
!insertmacro MUI_UNPAGE_INSTFILES

; 安装界面包含的语言设置
!insertmacro MUI_LANGUAGE "SimpChinese"

; 安装预释放文件
!insertmacro MUI_RESERVEFILE_INSTALLOPTIONS
; ------ MUI 现代界面定义结束 ------

Name "${PRODUCT_NAME}-${VERSION_NAME}v${PRODUCT_VERSION}"
OutFile "${PRODUCT_NAME}${VERSION_NAME}v${PRODUCT_VERSION}.exe"
InstallDir "C:\CYY"
ShowInstDetails show
ShowUnInstDetails show

Section "MainSection" SEC01
  SetOutPath "C:\CYY"
  ;SetOverwrite ifnewer
  ;SetOverwrite off
  SetOverwrite on ;覆盖安装
  File /r "CYY\*.*"
SectionEnd

Section -AdditionalIcons
  SetOutPath $INSTDIR
  CreateDirectory "$SMPROGRAMS\彩盈盈网络科技有限公司"
  CreateShortCut "$SMPROGRAMS\彩盈盈网络科技有限公司\Uninstall.lnk" "$INSTDIR\uninstall.exe"
  CreateShortCut "$SMPROGRAMS\彩盈盈网络科技有限公司\彩盈盈.lnk" "$INSTDIR\彩盈盈.exe"
  CreateShortCut "$SMPROGRAMS\彩盈盈.lnk" "$INSTDIR\彩盈盈.exe"
  CreateShortCut "$DESKTOP\彩盈盈.lnk" "$INSTDIR\彩盈盈.exe"
SectionEnd

Section -Post
  WriteUninstaller "$INSTDIR\uninstall.exe"
  WriteRegStr ${PRODUCT_UNINST_ROOT_KEY} "${PRODUCT_UNINST_KEY}" "DisplayName" "$(^Name)"
  WriteRegStr ${PRODUCT_UNINST_ROOT_KEY} "${PRODUCT_UNINST_KEY}" "UninstallString" "$INSTDIR\uninstall.exe"
  WriteRegStr ${PRODUCT_UNINST_ROOT_KEY} "${PRODUCT_UNINST_KEY}" "DisplayVersion" "${PRODUCT_VERSION}"
  WriteRegStr ${PRODUCT_UNINST_ROOT_KEY} "${PRODUCT_UNINST_KEY}" "DisplayIcon" "$INSTDIR\config\img\icon.ico"
  WriteRegStr ${PRODUCT_UNINST_ROOT_KEY} "${PRODUCT_UNINST_KEY}" "Publisher" "彩盈盈网络科技有限公司"
  
  WriteRegStr HKCU "${PRODUCT_UNINST_KEY}" "DisplayName" "${PRODUCT_NAME}"
  WriteRegStr HKCU "${PRODUCT_UNINST_KEY}" "VersionName" "${VERSION_NAME}"
  WriteRegStr HKCU "${PRODUCT_UNINST_KEY}" "DisplayVersion" "${PRODUCT_VERSION}"
  
	;http://blog.sina.com.cn/s/blog_407c173601007v2n.html
	;WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\$(^Name)" "InstallLocation" "$INSTDIR"
  ;WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\$(^Name)" "DisplayIcon" "CYY\config\img\icon.ico"
  ;WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\$(^Name)" "Publisher" "彩盈盈网络科技有限公司"
SectionEnd

/******************************
 *  以下是安装程序的卸载部分  *
 ******************************/

Section Uninstall
  Delete "$INSTDIR\uninstall.exe"

  Delete "$SMPROGRAMS\彩盈盈网络科技有限公司\Uninstall.lnk"
  
	Delete "$DESKTOP\彩盈盈.lnk"
	
	Delete "$SMPROGRAMS\彩盈盈.lnk"
	
  RMDir "$SMPROGRAMS\彩盈盈网络科技有限公司"

  RMDir /r "C:\CYY"

  RMDir "$INSTDIR"

  DeleteRegKey ${PRODUCT_UNINST_ROOT_KEY} "${PRODUCT_UNINST_KEY}"
  SetAutoClose true
SectionEnd

#-- 根据 NSIS 脚本编辑规则，所有 Function 区段必须放置在 Section 区段之后编写，以避免安装程序出现未可预知的问题。--#

Function un.onInit
  MessageBox MB_ICONQUESTION|MB_YESNO|MB_DEFBUTTON2 "您确实要完全移除 $(^Name) ，及其所有的组件？" IDYES +2
  Abort
FunctionEnd

Function un.onUninstSuccess
  HideWindow
  MessageBox MB_ICONINFORMATION|MB_OK "$(^Name) 已成功地从您的计算机移除。"
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
    "检测到本机已经安装 $(^Name) ${PRODUCT_VERSION}?\
    $\n$\n是否先卸载已安装的版本?" \
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
