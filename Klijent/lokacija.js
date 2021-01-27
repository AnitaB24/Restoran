export class Lokacija{
constructor(i,j,Maxkapacitet){
    this.x=i;
    this.y=j;
    this.kapacitet=0;
    this.Maxkapacitet=6;

    this.miniKontejner=null;

}
vratiSliku(){
    let image=document.createElement("img");
    image.className="slika";
    image="url('sto.png')";
    
    return image;
    
}
crtajLokaciju(host){
    
    this.miniKontejner=document.createElement("div");
    this.miniKontejner.className="lok";
    this.miniKontejner.innerHTML="prazno, "+this.kapacitet;
    this.miniKontejner.style.backgroundImage=this.vratiSliku();
  
 
    host.appendChild(this.miniKontejner);
    
    

}
azurirajLokaciju(kolicina,x,y){

    if(kolicina+this.kapacitet>this.Maxkapacitet)
    alert("kapacitet je popunjen");
    else{
    
        this.kapacitet+=kolicina;
        this.miniKontejner.innerHTML=this.kapacitet;
        
    }
}

}