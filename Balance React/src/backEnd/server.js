import express from "express";
import mongoose from "mongoose";
import cors from "cors";
import dotenv from "dotenv";
import path from "path";  

dotenv.config({
    path: path.resolve("src/backEnd/.env")
});

const app = express();
app.use(cors());
app.use(express.json());

mongoose.connect(process.env.MONGODB_URI)
.then(()=> console.log("Conectado a Mongo Atlas"))
.catch(err => console.log(err));

app.get("/", (req, res) => {
    res.send("API funcionando con ESM");
});

app.listen(process.env.PORT, () => console.log("Servidor listo en el puerto " + process.env.PORT));