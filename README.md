ShadowsocksR for Windows
=======================

[![Build Status]][Appveyor]

#### 功能扩展

实际使用过程中需要经常切换直连和 PAC模式，每次通过右下角去开启比较麻烦，所以增加了快捷键方便切换。

#### Download

You will need to download and install [7-Zip](http://www.7-zip.org/) in order 
to extract the ShadowsocksR archive.

Download the [latest release] for ShadowsocksR for Windows.

_Optionally_, right-click on the downloaded 7z file and select 
**CRC SHA** > **SHA-256**. Verify that the SHA-256 checksum displayed 
matches the expected checksum which was shown on the releases page.

Right-click on the downloaded 7z file and do **7-Zip** > **Extract Here** 
or extract to a new folder.

_Optionally_, download and install [Gpg4win](https://www.gpg4win.org/). 
From the Windows start menu, launch program **Kleopatra**. 
Do **File** > **New Certificate** to create a personal OpenPGP key pair. 
Save the signing key from
[breakwa11/pubkey](https://github.com/breakwa11/pubkey) as a text file. 
Then do **File** > **Import Certificates** to import the signing key text file.
After import, select the signing key and do 
**Certificates** > **Certify Certificates**. 
You will need to enter the passphrase for your own key. 
Finally, do **File** > **Decrypt/Verify Files** for the executable 
you propose to use (see below). A message confirming successful verification 
of the signature appears against a green background. 
Close program **Kleopatra**.

For >= Windows 8 or with .Net 4.0, using ShadowsocksR-dotnet4.0.exe.

For <= Windows 7 or with .Net 2.0, using ShadowsocksR-dotnet2.0.exe.

#### Usage

1. Find ShadowsocksR icon in the notification tray
2. You can add multiple servers in servers menu
3. Select Enable System Proxy menu to enable system proxy. Please disable other
proxy addons in your browser, or set them to use system proxy
4. You can also configure your browser proxy manually if you don't want to enable
system proxy. Set Socks5 or HTTP proxy to 127.0.0.1:1080. You can change this
port in Global settings
5. You can change PAC rules by editing the PAC file. When you save the PAC file
with any editor, ShadowsocksR will notify browsers about the change automatically
6. You can also update the PAC file from GFWList. Note your modifications to the PAC
file will be lost. However you can put your rules in the user rule file for GFWList.
Don't forget to update from GFWList again after you've edited the user rule
7. For UDP, you need to use SocksCap or ProxyCap to force programs you want
to proxy to tunnel over ShadowsocksR
8. 快捷键的设置在托盘里右键就能看到，设置完成后点击确定就可以设置，如果不需要设置只要按Delete或Backspace清空。

### Develop

Visual Studio Express 2012 is recommended.

#### License

GPLv3

Copyright © BreakWa11 2017. Fork from Shadowsocks by clowwindy

[Appveyor]:       https://ci.appveyor.com/project/breakwa11/shadowsocksr-csharp
[Build Status]:   https://ci.appveyor.com/api/projects/status/itcxnad1y95gf2x5/branch/master?svg=true
[latest release]: https://github.com/shadowsocksr/shadowsocksr-csharp/releases
