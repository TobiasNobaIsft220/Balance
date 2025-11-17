import express from "express";
import mongoose from "mongoose";
import cors from "cors";
import dotenv from "dotenv";

dotenv.config();

const app = express();
app.use(cors());
app.use(express.json());

mongoose.connect(process.env.MONGODB_URI)
.then(()=> console.log("Conectado a Mongo Atlas"))
.catch(err => console.log(err));

app.get("/", (req, res) => {
    res.send("API funcionando con ESM");
});

app.listen(PORT, () => console.log("Servidor listo en el puerto " + PORT));