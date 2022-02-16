import Name from './Name';

function Time(){
    return (
        <div>
            <p>It's currently {new Date().toLocaleTimeString()}. Thank you for asking, {<Name name = "Marko"/>}</p>
        </div>
    )
}
setInterval(Time,1000);

export default Time;