const { Res_PLC } = require('./configs');
var mc = require('mcprotocol');
var plc = new mc();
plc.initiateConnection({port: 5002, host: '192.168.1.101', ascii: false}, connect_plc); 
function connect_plc(err) {
    if (typeof (err) !== "undefined") {
        console.log(err);
        process.exit();
    }
    plc.setTranslationCB(function (tag) {
        return Res_PLC[tag];
    });
    plc.addItems(Object.keys(Res_PLC));
}
module.exports = {
    connect_plc,
    plc,
};