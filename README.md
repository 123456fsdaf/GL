# GenshinImpact_Lanucher
> 使用WinUI3开发！

### 此分支为WinUI3分支，采用更流畅的设计，更加现代的UI，加上无缝的UI动画，呈现更好的效果。

### WinUI3简介
你可能使用过微软的UWP应用，比如说Win10的设置，Win11的应用商店等，都是基于UWP平台打造。但是对于开发人员来说有很多的缺点，比如说

- 无法直接检索磁盘
- 无法使用系统代理
- 无法对系统进行外部设置，只能通过版本SDK。
但是，新的UI框架出现了，他是微软多年来发布UWP以及WPF的结合体，集合了微软多年的桌面开发经验，对于系统层的UI进行解耦（继承WinUI2.8的UI），不与高版本的系统SDK产生依赖，只要是Win10 1809以上版本皆可直接运行WinUI3框架。

## 基于WPF版的新特性
- 原生的云母和亚克力效果切换
- 采用纯页面导航，不采用缓存残留的方式，使运行时的内存降低到70-80mb左右。

## 故障
- WinUI3目前是1.1版本，还未引进系统代理，导致私服页面目前无法进行开发，但会去重新开一个项目来开启系统代理，目标框架为.Net framework或core。

### 为Win11设计！

解锁帧率：[DGP.Genshin.FPSunlocking](https://github.com/DGP-Studio/DGP.Genshin.FPSUnlocking)
