set fdir=%WINDIR%\Microsoft.NET\Framework64

if not exist %fdir% (
	set fdir=%WINDIR%\Microsoft.NET\Framework
)

set msbuild=C:\Windows\Microsoft.NET\Framework\v4.0.30319\msbuild.exe
%msbuild% ../src/Raven.Rpc.HttpProtocol/Raven.Rpc.HttpProtocol/Raven.Rpc.HttpProtocol.csproj /t:Clean;Rebuild /p:Configuration=Release;VisualStudioVersion=12.0;OutputPath="..\..\..\output\net45\Raven.Rpc.HttpProtocol"

::set msbuild=C:\Windows\Microsoft.NET\Framework\v4.0.30319\msbuild.exe
::%msbuild% ../src/Raven.Rpc.HttpProtocol/Raven.Rpc.HttpProtocol40/Raven.Rpc.HttpProtocol40.csproj /t:Clean;Rebuild /p:Configuration=Release;VisualStudioVersion=12.0;OutputPath="..\..\..\output\net40\Raven.Rpc.HttpProtocol"

set msbuild=C:\Windows\Microsoft.NET\Framework\v4.0.30319\msbuild.exe
%msbuild% ../src/Raven.Rpc.HttpProtocol/Raven.Rpc.IContractModel/Raven.Rpc.IContractModel.csproj /t:Clean;Rebuild /p:Configuration=Release;VisualStudioVersion=12.0;OutputPath="..\..\..\output\net45\Raven.Rpc.IContractModel"

::set msbuild=C:\Windows\Microsoft.NET\Framework\v4.0.30319\msbuild.exe
::%msbuild% ../src/Raven.Rpc.HttpProtocol/Raven.Rpc.IContractModel/Raven.Rpc.IContractModel.csproj /t:Clean;Rebuild /p:Configuration=Release;VisualStudioVersion=12.0;OutputPath="..\..\..\output\net40\Raven.Rpc.IContractModel"


pause