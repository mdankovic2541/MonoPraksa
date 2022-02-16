import Name from './Name';
import Time from './Time';

function CreateParagraph(){
    return(
        <div className="CreateParagraph">
            <p>Hello, {<Name name="Marko"/>}</p>
            <p>{<Time />}</p>
            <span>I am {Math.abs(-20)} years old.</span>
        </div>
    );
}

export default CreateParagraph;