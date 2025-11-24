//Importaciones de los modulos necesarios
import express from "express";
import mongoose from "mongoose";
import cors from "cors";
import dotenv from "dotenv";
import userRouter from "./routes/user.routes.js";

//Define donde se encuentra el archivo .env
dotenv.config();

const MONGODB_URI = process.env.MONGODB_URI;

const PORT = process.env.PORT || 3000;

//Crea el servidor con express
const app = express();

//Habilita el uso de cors para que se puedan comunicar diferentes dominios y puertos
app.use(cors());

//Le permite a express leer cuerpos json
app.use(express.json());

//Definicion de las rutas de las APIs
app.use("/api/", userRouter);

//Conecta a mi base de datos en Mongo Atlas. Si no se puede conectar me manda el error  a la consola
mongoose.connect(MONGODB_URI)
.then(()=> console.log("Conectado a Mongo Atlas"))
.catch(err => console.log(err));

//Validacion de que base de datos y coleccion se esta utilizando
mongoose.connection.on("connected", () => {
  console.log("Conectado a:", mongoose.connection.name);
  console.log("Colecciones:", Object.keys(mongoose.connection.collections));
});

//API principal para verificar que funciona el servidor
app.get("/", (req, res) => {
    res.send("API funcionando con ESM");
});


//Abre el servidor en el puerto 3000
app.listen(PORT, () => console.log("Servidor listo en el puerto " + PORT));