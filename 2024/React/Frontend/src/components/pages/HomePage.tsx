import {Layout} from "../organisms";
import {Figure, FigureImage, Form} from "react-bootstrap";
import Button from "react-bootstrap/Button";
import {api} from "../../api";
import React, {ChangeEventHandler, FormEventHandler, useState} from "react";

export const HomePage = () => {
    const [file, setFile] = useState<File>();
    const [photoUrl, setPhotoUrl] = useState<string>()

    const onSubmit: FormEventHandler = (e) => {
        e.preventDefault();

        const formData = new FormData();
        file !== undefined && formData.append('file', file);
        file !== undefined && formData.append('fileName', file.name);

        api()
            .post("/api/photos", formData, {
                headers: {
                    'content-type': 'multipart/form-data',
                },
            })
            .then(response => setPhotoUrl(response.headers.location));
    }

    const onFileChange: ChangeEventHandler<HTMLInputElement> = (e) => {
        if (e.target.files === null)
            return;

        setFile(e.target.files[0]);
    }

    return <Layout>


        <h2>Photo Form</h2>
        <Form onSubmit={onSubmit} className="bg-dark-subtle rounded-4 p-4">
            <Form.Group className="mb-3">
                <Form.Label>Photo</Form.Label>
                <Form.Control type="file" onChange={onFileChange}></Form.Control>
            </Form.Group>
            <Button variant="primary" type="submit">
                Submit
            </Button>
        </Form>

        {photoUrl && <Figure className="mt-3">
            <FigureImage src={photoUrl} width={200} className="rounded-4 shadow"/>
            <Figure.Caption>My beautifull upload</Figure.Caption>
            
        </Figure>}
        
        <hr className="my-5"/>

        <h2>Hello, world!</h2>
        <p>Welcome to your new single-page application, built with:</p>
        <ul>
            <li>
                <a href="https://get.asp.net/">ASP.NET Core</a> and{" "}
                <a href="https://msdn.microsoft.com/en-us/library/67ef8sbd.aspx">C#</a>{" "}
                for cross-platform server-side code
            </li>
            <li>
                <a href="https://facebook.github.io/react/">React</a> for client-side
                code
            </li>
            <li>
                <a href="http://getbootstrap.com/">Bootstrap</a> for layout and styling
            </li>
        </ul>
        <p>To help you get started, we have also set up:</p>
        <ul>
            <li>
                <strong>Client-side navigation</strong>. For example, click{" "}
                <em>Counter</em> then <em>Back</em> to return here.
            </li>
            <li>
                <strong>Development server integration</strong>. In development mode,
                the development server from <code>create-react-app</code> runs in the
                background automatically, so your client-side resources are dynamically
                built on demand and the page refreshes when you modify any file.
            </li>
            <li>
                <strong>Efficient production builds</strong>. In production mode,
                development-time features are disabled, and your{" "}
                <code>dotnet publish</code> configuration produces minified, efficiently
                bundled JavaScript files.
            </li>
        </ul>
        <p>
            The <code>Frontend</code> subdirectory is a standard React application
            based on the <code>create-react-app</code> template. If you open a command
            prompt in that directory, you can run <code>npm</code> commands such as{" "}
            <code>npm test</code> or <code>npm install</code>.
        </p>
    </Layout>
}
