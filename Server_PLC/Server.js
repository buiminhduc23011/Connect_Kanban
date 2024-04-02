const { MAC } = require('./configs');
const { dataController } = require('./controller');
const { connect_plc, plc } = require('./PLC');
async function read_plc() {
  try {
    const plcData = await dataController(plc);
    console.log(plcData);
  } catch (error) {
    console.error('Error reading PLC data:', error);
  }
}
async function main() {
  try {
    connect_plc();
    setInterval(read_plc, 1000);
  } catch (error) {
    console.error('Error in main:', error);
  }
}
main();
