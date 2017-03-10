# TaoShang #
TaoShang 是一个使用 .NET 开发的淘宝自助刷单平台。项目使用了 Dapper（ORM），SQLite，Ninject（IOC）protobuf.net 等开源项目及远程桌面软件 AnyDesk。客户端与服务端使用基于 SEA 的 Socket TCP 进行通信。

# 项目目录说明 #
- starts2000  一些基础类库及基于 SEA 的 Socket TCP 封装。
- Starts2000.SmartUpdate 程序自动更新客户端及服务端项目。
- Starts2000.TaobaoPlatform.Manager TaoShang 后台管理项目。
- Starts2000.TaobaoPlatform.Server TaoShang 服务端。
- Starts2000.TaoBaoTool/Starts2000.TaoBaoTool TaoShang 刷单操作端。
- Starts2000.TaoBaoTool/Starts2000.TaoBaoTool.Client TaoShang 刷单挂机端。
