const express = require("express");
const app = express();
const { dataController, plc1_controller } = require('./controller');
const { connect_plc, plc } = require('./PLC');

const bodyParser = require("body-parser");
//
connect_plc();
app.use(bodyParser.json());
app.get("/api/data", (req, res) => {
  dataController(plc, req, res);
});
app.post("/api/Control_PLC",(req, res) => { plc1_controller(plc, req, res);});
app.listen(8080, () => {
  console.log("Server started on port 8080");
});