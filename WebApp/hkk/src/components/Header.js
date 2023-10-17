import React from 'react'

const Header = () => {
    return (
        <>
            <header>

                <div className='container'>
                    <div className='header__wrapper'>
                        <div className='header__logo'>
                            <img src='https://static.tildacdn.com/tild6137-3639-4364-a233-316662356666/Asset_7logo.png'/>
                        </div>
                        <div className="header__login">
                                <button>
                                    Войти
                                </button>
                        </div>

                    </div>
                </div>
            </header>
        </>
    )
}

export default Header