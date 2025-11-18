//Importaciones de los modulos necesarios
import express from "express";
import mongoose from "mongoose";
import cors from "cors";
import dotenv from "dotenv";

//Define donde se encuentra el archivo .env
dotenv.config();

//Crea el servidor con express
const app = express();

//Habilita el uso de cors para que se puedan comunicar diferentes dominios y puertos
app.use(cors());

//Le permite a express leer cuerpos json
app.use(express.json());


//Conecta a mi base de datos en Mongo Atlas. Si no se puede conectar me manda el error  a la consola
mongoose.connect(process.env.MONGODB_URI)
.then(()=> console.log("Conectado a Mongo Atlas"))
.catch(err => console.log(err));

//API principal para verificar que funciona el servidor
app.get("/", (req, res) => {
    res.send("API funcionando con ESM");
});

//Abre el servidor en el puerto 3000
app.listen(process.env.PORT, () => console.log("Servidor listo en el puerto " + process.env.PORT));