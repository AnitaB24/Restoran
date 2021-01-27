import {FastFood} from "./fastfood.js"

/*const cezar=new FastFood("Cezar",5,4,6);
cezar.crtajObjekat(document.body);*/
let main=document.createElement("div");
main.className="crtanje";
document.body.appendChild(main);
const kontejner3=document.createElement("div");
kontejner3.className="main";
main.appendChild(kontejner3);
let label = document.createElement("br");
kontejner3.appendChild(label);
label=document.createElement("h2");
label.innerHTML="Crtanje restorana";
kontejner3.appendChild(label);
const crtaj=document.createElement("button");
crtaj.className="btnCrtaj";
crtaj.innerHTML="Crtaj restorane";
kontejner3.appendChild(crtaj);
crtaj.onclick=(ev)=>
{
fetch("https://localhost:5001/FastFood/PreuzmiRestoran").then(p=>{
    p.json().then(data=>{
       data.forEach(res=>{
           const rest=new FastFood(res.naziv,res.n,res.m,res.kapacitet);
        rest.crtajObjekat(document.body);

       // res.lokacije.forEach(l => {
         //  rest.lokacije[l.x * res.n + l.y].azurirajLokaciju(l.x, l.y,l.kapacitet);
        //});
    });
});
});
}


let main1=document.createElement("div");
main1.className="brisanje";
document.body.appendChild(main1);
const kontejner4=document.createElement("div");
kontejner4.className="kont4";
main1.appendChild(kontejner4);
let label4 = document.createElement("br");
kontejner4.appendChild(label4);
label4=document.createElement("h2");
label4.innerHTML="Brisanje restorana";
let label5=document.createElement("h2");
label5.innerHTML="sa ID brojem:";
kontejner4.appendChild(label4);
kontejner4.appendChild(label5);
let input = document.createElement("input");
input.className="id1";
input.type="number";
kontejner4.appendChild(input);

const izbrisi=document.createElement("button");
izbrisi.className="btnIzbrisi";
izbrisi.innerHTML="Izbrisi restoran";
kontejner4.appendChild(izbrisi);
izbrisi.onclick=(ev)=>{
    let id=document.querySelector(".id1").value;
    fetch("https://localhost:5001/FastFood/IzbrisiRestoran?id="+id,{method:"DELETE"}).then(p=>{if(p.ok){location.reload();}});
}


