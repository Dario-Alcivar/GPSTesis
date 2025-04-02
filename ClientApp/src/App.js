import React, { Suspense, useEffect } from 'react';
import { HashRouter, Route, Routes } from 'react-router-dom';
import { useSelector } from 'react-redux';
import { CSpinner, useColorModes } from '@coreui/react';

import './scss/style.scss';
import './scss/examples.scss';

// Containers
const DefaultLayout = React.lazy(() => import('./layout/DefaultLayout'));

// Pages
const Login = React.lazy(() => import('./views/pages/login/Login'));
const Register = React.lazy(() => import('./views/pages/register/Register'));
const Page404 = React.lazy(() => import('./views/pages/page404/Page404'));
const Page500 = React.lazy(() => import('./views/pages/page500/Page500'));

const App = () => {
    const { isColorModeSet, setColorMode } = useColorModes('coreui-free-react-admin-template-theme');
    const storedTheme = useSelector((state) => state.theme);

    useEffect(() => {
        const urlParams = new URLSearchParams(window.location.search);
        const theme = urlParams.get('theme');

        if (theme && /^[A-Za-z0-9\s]+$/.test(theme)) {
            setColorMode(theme);
        }

        if (!isColorModeSet()) {
            setColorMode(storedTheme);
        }
    }, [storedTheme, isColorModeSet, setColorMode]);

    return (
        <HashRouter>
            <Suspense
                fallback={
                    <div className="pt-3 text-center">
                        <CSpinner color="primary" variant="grow" />
                    </div>
                }
            >
                <Routes>
                    <Route path="/login" element={<Login />} />
                    <Route path="/register" element={<Register />} />
                    <Route path="/404" element={<Page404 />} />
                    <Route path="/500" element={<Page500 />} />
                    <Route path="*" element={<DefaultLayout />} />
                </Routes>
            </Suspense>
        </HashRouter>
    );
};

export default App;
