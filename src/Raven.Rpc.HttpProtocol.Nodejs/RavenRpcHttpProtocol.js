/** @license
 * RavenRpcHttpProtocol.js <>
 * Author: indifer | MIT License
 * Email: indifer@126.com
 * v0.0.1 (2015/12/3 14:00)
 */

;
(function (global, $) {

	function RpcHttpClient() {

	}
	
	var rpcHttpClient = new RpcHttpClient();
	rpcHttpClient.fn = RpcHttpClient.prototype;
	global['rpcHttpClient'] = rpcHttpClient;
	
	return rpcHttpClient;

})(this, jQuery || Zepto || $);