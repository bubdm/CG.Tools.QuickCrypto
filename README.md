# CG.Tools.QuickCrypto: 
---
[![Build Status](https://dev.azure.com/codegator/CG.Tools.QuickCrypto/_apis/build/status/CodeGator.CG.Tools.QuickCrypto?branchName=main)](https://dev.azure.com/codegator/CG.Tools.QuickCrypto/_build/latest?definitionId=21&branchName=main)
[![Github docs](https://img.shields.io/static/v1?label=Documentation&message=online&color=blue)](https://codegator.github.io/CG.Tools.QuickCrypto/index.html)
![Azure DevOps coverage](https://img.shields.io/azure-devops/coverage/codegator/CG.Tools.QuickCrypto/21)

#### What does it do?
A tool for quick encryption / decryption, developed by CodeGator.

##### Quick Note:
This project uses Syncfusion controls for the UI. We took that approach, as opposed to rolling our own, or using open source alternatives, because:

* They're free, provided you sign up for the ridiculously generous Syncfusion Community License, [HERE](https://www.syncfusion.com/products/communitylicense)
* They already written, which means we can focus on this tool rather than worring about reinventing WPF controls, from scratch.
* They are supported, which is more than most open source control packages can say.
* Did we mention they are FREE?? Seriously, go [HERE](https://www.syncfusion.com/products/communitylicense) and sign up!

If you do get your own Syncfusion license, you'll need to add your license key to the appSettings.json file, like this:

```
{
  "Syncfusion": "Your Syncfusion license here"
}
```

If you don't add your Syncfusion key to the appSetting.json, as shown above, you'll see a popup like this at runtime:

![The main UI](https://github.com/CodeGator/CG.Tools.QuickCrypto/blob/main/images/syncfusion.jpg)

Just press Close. The popup means the Syncfusion library didn't find a license, so it's starting in 'trial mode'. 

It's alright, the tool will work without the Syncfusion license.


##### UI walk through:
Here is the overal UI, with the DPAPI tab selected:

![DPAPI tab](https://github.com/CodeGator/CG.Tools.QuickCrypto/blob/main/images/dpapi.jpg)

Here is the overal UI, with the Rijndael tab selected.

![Rijndael tab](https://github.com/CodeGator/CG.Tools.QuickCrypto/blob/main/images/rijndael.jpg)



#### How do I contact you?
If you've spotted a bug in the code please use the project Issues [HERE](https://github.com/CodeGator/CG.Tools.QuickCrypto/issues)

#### Is there any documentation?
There is developer documentation [HERE](https://codegator.github.io/CG.Tools.QuickCrypto/)

We also blog about projects like this one on our website, [HERE](http://www.codegator.com)